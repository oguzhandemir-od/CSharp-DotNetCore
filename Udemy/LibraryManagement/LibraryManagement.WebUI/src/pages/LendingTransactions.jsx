import React, { useState, useEffect } from 'react';
import api from '../api/axiosInstance'; 

export default function LendingTransactions() {
  const [transactions, setTransactions] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  
  const [isLoanModalOpen, setIsLoanModalOpen] = useState(false);
  const [isReturnModalOpen, setIsReturnModalOpen] = useState(false);
  const [selectedTransaction, setSelectedTransaction] = useState(null);
  
  const [searchQuery, setSearchQuery] = useState('');
  const [filterStatus, setFilterStatus] = useState('all');

  const [currentStaffId, setCurrentStaffId] = useState(0);

  const [loanFormData, setLoanFormData] = useState({
    MemberId: '',
    BookId: ''
  });

  useEffect(() => {
    const token = localStorage.getItem('library_token');
    if (token) {
      try {
        const base64Url = token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        const payload = JSON.parse(window.atob(base64));
        
        const staffId = payload.nameid || payload.Id || 1; 
        setCurrentStaffId(parseInt(staffId));
      } catch (e) {
        console.error("Token'dan StaffId alınamadı:", e);
      }
    }
  }, []);

  const fetchTransactions = async () => {
    setIsLoading(true);
    try {
      const response = await api.get('/Loan');
      setTransactions(response.data || []);
    } catch (error) {
      console.error("Ödünç kayıtları yüklenirken hata oluştu:", error);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    fetchTransactions();
  }, []);

  const filteredTransactions = transactions.filter(t => {
    const memberName = t.memberFullName ?? t.MemberFullName ?? '';
    const bookName = t.bookName ?? t.BookName ?? '';
    const isReturned = t.isReturned ?? t.IsReturned ?? false;
    const dueDateStr = t.dueDate ?? t.DueDate;

    const matchesSearch = memberName.toLowerCase().includes(searchQuery.toLowerCase()) || 
                          bookName.toLowerCase().includes(searchQuery.toLowerCase());
    
    let status = isReturned ? 'returned' : 'active';
    if (!isReturned && dueDateStr && new Date(dueDateStr) < new Date()) {
      status = 'overdue';
    }

    const matchesStatus = filterStatus === 'all' || status === filterStatus;
    return matchesSearch && matchesStatus;
  });

  const handleCreateLoan = async (e) => {
    e.preventDefault();
    try {
      const payload = {
        MemberId: parseInt(loanFormData.MemberId),
        BookId: parseInt(loanFormData.BookId),
        StaffId: currentStaffId 
      };

      await api.post('/Loan', payload);
      setIsLoanModalOpen(false);
      setLoanFormData({ MemberId: '', BookId: '' });
      fetchTransactions(); 
    } catch (error) {
      console.error("Ödünç verme hatası:", error);
      alert(error.response?.data || 'İşlem gerçekleştirilemedi. Bilgileri kontrol edin.');
    }
  };

  const handleReturnBook = async (e) => {
    e.preventDefault();
    if (!selectedTransaction) return;

    try {
      const payload = {
        LoanId: selectedTransaction.id 
      };

      await api.post('/Loan/return', payload); 
      
      setIsReturnModalOpen(false);
      setSelectedTransaction(null);
      fetchTransactions(); 
    } catch (error) {
      console.error("İade alma hatası:", error);
      alert(error.response?.data || 'İade işlemi sırasında bir hata oluştu.');
    }
  };

  const StatusBadge = ({ isReturned, dueDateStr }) => {
    let status = isReturned ? 'returned' : 'active';
    if (!isReturned && dueDateStr && new Date(dueDateStr) < new Date()) {
      status = 'overdue';
    }

    const styles = {
      active: "bg-blue-50 text-blue-700 border-blue-200",
      overdue: "bg-rose-50 text-rose-700 border-rose-200 animate-pulse",
      returned: "bg-emerald-50 text-emerald-700 border-emerald-200"
    };
    const labels = {
      active: "Aktif Ödünçte",
      overdue: "Süresi Geçmiş!",
      returned: "İade Edildi"
    };

    return (
      <span className={`px-2.5 py-1 rounded-full text-xs font-semibold border ${styles[status]}`}>
        {labels[status]}
      </span>
    );
  };

  return (
    <div className="space-y-6">
      {/* Üst Başlık */}
      <div className="flex flex-col sm:flex-row justify-between items-start sm:items-center gap-4">
        <div>
          <h2 className="text-2xl font-bold text-slate-800">Ödünç / İade Trafiği</h2>
          <p className="text-sm text-slate-500 mt-1">Sistemdeki tüm kitap teslim ve alış sirkülasyonunu yönetin.</p>
        </div>
        <button 
          onClick={() => setIsLoanModalOpen(true)}
          className="bg-indigo-600 hover:bg-indigo-700 text-white px-4 py-2.5 rounded-lg flex items-center gap-2 transition-all shadow-sm hover:shadow-md font-medium cursor-pointer"
        >
          <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 6v6m0 0v6m0-6h6m-6 0H6"></path></svg>
          Yeni Ödünç Ver
        </button>
      </div>

      {/* Filtreleme ve Arama Çubuğu */}
      <div className="bg-white p-4 rounded-xl shadow-sm border border-slate-200 flex flex-col sm:flex-row gap-4">
        <div className="relative flex-1">
          <svg className="absolute left-3 top-1/2 -translate-y-1/2 w-5 h-5 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"></path></svg>
          <input 
            type="text" 
            placeholder="Üye adı veya kitap adı ile ara..." 
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
            className="w-full pl-10 pr-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none transition-all text-sm"
          />
        </div>
        <select 
          value={filterStatus}
          onChange={(e) => setFilterStatus(e.target.value)}
          className="px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none bg-white sm:w-48 text-sm text-slate-700"
        >
          <option value="all">Tüm Durumlar</option>
          <option value="active">Aktif Ödünçler</option>
          <option value="overdue">Süresi Geçenler</option>
          <option value="returned">İade Edilenler</option>
        </select>
      </div>

      {/* Veri Tablosu */}
      <div className="bg-white rounded-xl shadow-sm border border-slate-200 overflow-hidden">
        {isLoading ? (
          <div className="p-12 flex justify-center items-center text-slate-400">
            <svg className="animate-spin h-8 w-8 text-indigo-600" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
              <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
              <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
            </svg>
          </div>
        ) : (
          <div className="overflow-x-auto">
            <table className="w-full text-left border-collapse">
              <thead className="bg-slate-50 border-b border-slate-200">
                <tr>
                  <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Üye</th>
                  <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Kitap</th>
                  <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Ödünç / Son Teslim Tarihi</th>
                  <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider text-center">Durum</th>
                  <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Ödünç Veren</th>
                  <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider text-center">İade Tarihi</th>
                  <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider text-right">İşlem</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {filteredTransactions.length === 0 ? (
                  <tr><td colSpan="5" className="px-6 py-8 text-center text-slate-500">Kayıtlı işlem akışı bulunamadı.</td></tr>
                ) : (
                  filteredTransactions.map((t) => {
                    const memberName = t.memberFullName ?? t.MemberFullName;
                    const bookName = t.bookName ?? t.BookName;
                    const loanDate = new Date(t.loanDate ?? t.LoanDate).toLocaleDateString('tr-TR');
                    const dueDate = new Date(t.dueDate ?? t.DueDate).toLocaleDateString('tr-TR');
                    const isReturned = t.isReturned ?? t.IsReturned;
                    const staffName=t.staffName??t.StaffName;
                    const returnDate=t.returnDate??t.ReturnDate;

                    const formatDate = (dateString) => {
  if (!dateString) return "Teslim Edilmedi"; 
  return dateString.split('T')[0]; 
};

                    return (
                      <tr key={t.id} className="hover:bg-slate-50 transition-colors">
                        <td className="px-6 py-4 text-sm font-semibold text-slate-900">{memberName}</td>
                        <td className="px-6 py-4 text-sm text-slate-600 max-w-xs truncate">{bookName}</td>
                        <td className="px-6 py-4 text-sm text-slate-600">
                          <div className="flex flex-col text-xs space-y-0.5">
                            <span>Veriliş: <span className="text-slate-900 font-medium">{loanDate}</span></span>
                            <span>Son Gün: <span className="text-indigo-600 font-medium">{dueDate}</span></span>
                          </div>
                        </td>
                        
                        <td className="px-6 py-4 text-sm text-center">
                          <StatusBadge isReturned={isReturned} dueDateStr={t.dueDate ?? t.DueDate} />
                        </td>
                        <td className="px-6 py-4 text-sm text-slate-600 max-w-xs truncate">{staffName}</td>
                        <td className="px-6 py-4 text-sm text-slate-600 max-w-xs truncate">{formatDate(returnDate)}</td>
                        <td className="px-6 py-4 text-sm text-right">
                          {!isReturned ? (
                            <button 
                              onClick={() => { setSelectedTransaction(t); setIsReturnModalOpen(true); }}
                              className="bg-emerald-600 hover:bg-emerald-700 text-white px-3 py-1.5 rounded-md text-xs font-semibold transition-colors inline-flex items-center gap-1 cursor-pointer shadow-sm"
                            >
                              İade Al
                            </button>
                          ) : (
                            <span className="text-slate-400 text-xs font-medium bg-slate-100 px-2 py-1 rounded">Kayıt Kapalı</span>
                          )}
                        </td>
                      </tr>
                    );
                  })
                )}
              </tbody>
            </table>
          </div>
        )}
      </div>

      {/* --- MODAL 1: ÖDÜNÇ VER (POST LoanCreateDto) --- */}
      {isLoanModalOpen && (
        <div className="fixed inset-0 bg-slate-900/50 backdrop-blur-sm flex items-center justify-center z-50 p-4">
          <div className="bg-white rounded-xl shadow-2xl w-full max-w-md overflow-hidden animate-in fade-in zoom-in duration-200">
            <div className="px-6 py-4 border-b border-slate-100 flex justify-between items-center bg-slate-50">
              <h3 className="text-lg font-semibold text-slate-800">Yeni Ödünç Verme Formu</h3>
              <button onClick={() => setIsLoanModalOpen(false)} className="text-slate-400 hover:text-slate-600 transition-colors cursor-pointer">
                <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M6 18L18 6M6 6l12 12"></path></svg>
              </button>
            </div>
            <form onSubmit={handleCreateLoan} className="p-6 space-y-4">
              <div>
                <label className="block text-sm font-medium text-slate-700 mb-1">Üye ID <span className="text-rose-500">*</span></label>
                <input 
                  type="number" 
                  required
                  value={loanFormData.MemberId}
                  onChange={(e) => setLoanFormData({...loanFormData, MemberId: e.target.value})}
                  className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm font-medium"
                  placeholder="Üye veritabanı ID'si"
                />
              </div>
              <div>
                <label className="block text-sm font-medium text-slate-700 mb-1">Kitap ID <span className="text-rose-500">*</span></label>
                <input 
                  type="number" 
                  required
                  value={loanFormData.BookId}
                  onChange={(e) => setLoanFormData({...loanFormData, BookId: e.target.value})}
                  className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm font-medium"
                  placeholder="Kitap veritabanı ID'si"
                />
              </div>
              <div className="bg-slate-50 p-3 rounded-lg border border-slate-200 text-xs text-slate-500">
                💡 Sistem kuralları gereği, ödünç süresi veriliş tarihinden itibaren otomatik olarak <strong>14 gün</strong> olarak backend tarafından tanımlanacaktır.
              </div>
              <div className="flex justify-end gap-3 pt-2">
                <button type="button" onClick={() => setIsLoanModalOpen(false)} className="px-4 py-2.5 border border-slate-300 text-slate-700 rounded-lg hover:bg-slate-50 transition-colors font-medium cursor-pointer">
                  İptal
                </button>
                <button type="submit" className="px-6 py-2.5 bg-indigo-600 text-white rounded-lg hover:bg-indigo-700 transition-colors shadow-sm font-medium cursor-pointer">
                  Ödünç Vermeyi Tamamla
                </button>
              </div>
            </form>
          </div>
        </div>
      )}

      {/* --- MODAL 2: İADE ALMA (POST LoanReturnDto) --- */}
      {isReturnModalOpen && selectedTransaction && (
        <div className="fixed inset-0 bg-slate-900/50 backdrop-blur-sm flex items-center justify-center z-50 p-4">
          <div className="bg-white rounded-xl shadow-2xl w-full max-w-md overflow-hidden animate-in fade-in zoom-in duration-200">
            <div className="px-6 py-4 border-b border-slate-100 bg-emerald-50 flex justify-between items-center">
              <h3 className="text-lg font-semibold text-emerald-800 flex items-center gap-2">
                Kitap İade İşlemi
              </h3>
              <button onClick={() => setIsReturnModalOpen(false)} className="text-emerald-400 hover:text-emerald-600 transition-colors cursor-pointer">
                <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M6 18L18 6M6 6l12 12"></path></svg>
              </button>
            </div>
            <form onSubmit={handleReturnBook} className="p-6 space-y-4">
              <div className="bg-slate-50 p-4 rounded-lg border border-slate-200 text-sm space-y-2 text-slate-700">
                <p><span className="font-semibold text-slate-600">Teslim Eden Üye:</span> {selectedTransaction.memberFullName ?? selectedTransaction.MemberFullName}</p>
                <p><span className="font-semibold text-slate-600">İade Edilen Kitap:</span> {selectedTransaction.bookName ?? selectedTransaction.BookName}</p>
                <p><span className="font-semibold text-slate-600">Öngörülen Son Gün:</span> {new Date(selectedTransaction.dueDate ?? selectedTransaction.DueDate).toLocaleDateString('tr-TR')}</p>
              </div>

              <div className="bg-amber-50 text-amber-800 p-3 rounded-lg border border-amber-200 text-xs">
                ⚠️ Onay verdiğinizde kitap stokları güncellenecek, gecikme var ise backend algoritmaları tarafından otomatik olarak <strong>Penalty (Ceza)</strong> kaydı üretilecektir.
              </div>

              <div className="flex justify-end gap-3 pt-2">
                <button type="button" onClick={() => setIsReturnModalOpen(false)} className="px-4 py-2.5 border border-slate-300 text-slate-700 rounded-lg hover:bg-slate-50 transition-colors font-medium cursor-pointer">
                  Vazgeç
                </button>
                <button type="submit" className="px-6 py-2.5 bg-emerald-600 text-white rounded-lg hover:bg-emerald-700 transition-colors shadow-sm font-medium cursor-pointer">
                  İadeyi Onayla ve Kapat
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
}