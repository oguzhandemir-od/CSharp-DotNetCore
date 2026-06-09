import React, { useState, useEffect } from 'react';
import api from '../api/axiosInstance'; 

export default function Members() {
  const [members, setMembers] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [editingMember, setEditingMember] = useState(null);
  const [searchQuery, setSearchQuery] = useState('');
  const [selectedMemberForPenalty, setSelectedMemberForPenalty] = useState(null);

  const [userRole, setUserRole] = useState('Staff'); 

  const [formData, setFormData] = useState({ 
    name: '', 
    surname: '', 
    email: '',
    password: '' 
  });
  const [formError, setFormError] = useState('');

  useEffect(() => {
    const token = localStorage.getItem('library_token');
    if (token) {
      try {
        const base64Url = token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        const payload = JSON.parse(window.atob(base64));
        
        const role = payload.StaffType || payload.staffType || 'Officer';
        setUserRole(role);
      } catch (e) {
        console.error("Token rolü çözümlenemedi:", e);
      }
    }
  }, []);

  const fetchMembers = async () => {
    setIsLoading(true);
    try {
      const response = await api.get('/Member'); 
      setMembers(response.data || []);
    } catch (error) {
      console.error("Üyeler yüklenirken hata oluştu:", error);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => { 
    fetchMembers(); 
  }, []);

  const openModal = (member = null) => {
    setEditingMember(member);
    if (member) {
      setFormData({
        name: member.name || member.Name || '',
        surname: member.surname || member.Surname || '',
        email: member.email || member.Email || '',
        password: '' 
      });
    } else {
      setFormData({ name: '', surname: '', email: '', password: '' });
    }
    setFormError('');
    setIsModalOpen(true);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!formData.name.trim() || !formData.surname.trim() || !formData.email.trim()) {
      setFormError('Ad, Soyad ve E-posta alanları zorunludur.');
      return;
    }

    try {
      if (editingMember) {
        await api.put(`/Member/${editingMember.id}`, {
          Name: formData.name,
          Surname: formData.surname,
          Email: formData.email
        });
      } else {
        await api.post('/Member', {
          Name: formData.name,
          Surname: formData.surname,
          Email: formData.email,
          Password: formData.password || "Kutuphane123!" 
        });
      }
      setIsModalOpen(false);
      fetchMembers(); 
    } catch (error) {
      console.error("Kaydetme hatası:", error);
      setFormError(error.response?.data || 'Kaydedilirken bir hata meydana geldi.');
    }
  };

  const handleDelete = async (id) => {
    if (userRole !== 'Admin' && userRole !== 'Manager') {
      alert('Bu işlemi gerçekleştirmek için Admin yetkiniz bulunmalıdır.');
      return;
    }

    if (!window.confirm('Bu üyeyi ve tüm geçmiş kayıtlarını silmek istediğinize emin misiniz?')) return;
    
    try {
      await api.delete(`/Member/${id}`);
      fetchMembers();
    } catch (error) {
      console.error("Silme hatası:", error);
      alert(error.response?.data || 'Silme işlemi başarısız oldu.');
    }
  };

  const filteredMembers = members.filter(m => {
    const fName = m.name || m.Name || '';
    const sName = m.surname || m.Surname || '';
    const email = m.email || m.Email || '';
    const fullName = `${fName} ${sName}`.toLowerCase();

    return fullName.includes(searchQuery.toLowerCase()) || 
           email.toLowerCase().includes(searchQuery.toLowerCase());
  });

  return (
    <div className="space-y-6">
      {/* Üst Başlık */}
      <div className="flex flex-col sm:flex-row justify-between items-start sm:items-center gap-4">
        <div>
          <h2 className="text-2xl font-bold text-slate-800">Üye Yönetimi</h2>
          <p className="text-sm text-slate-500 mt-1">Kütüphane üyelerini kaydedin, düzenleyin ve aktif/pasif durumlarını izleyin.</p>
        </div>
        
        {/* İşlevsel Yetki Kontrolü: Her personel yeni üye ekleyebilir */}
        <button onClick={() => openModal()} className="bg-indigo-600 hover:bg-indigo-700 text-white px-4 py-2.5 rounded-lg flex items-center gap-2 transition-all shadow-sm hover:shadow-md font-medium cursor-pointer">
          <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 4v16m8-8H4"></path></svg>
          Yeni Üye Ekle
        </button>
      </div>

      {/* Arama Alanı */}
      <div className="relative max-w-md">
        <svg className="absolute left-3 top-1/2 -translate-y-1/2 w-5 h-5 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"></path></svg>
        <input type="text" placeholder="Üye adı, soyadı veya e-posta ile ara..." value={searchQuery} onChange={(e) => setSearchQuery(e.target.value)} className="w-full pl-10 pr-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" />
      </div>

      {/* Veri Tablosu */}
      <div className="bg-white rounded-xl shadow-sm border border-slate-200 overflow-hidden">
        {isLoading ? (
          <div className="p-12 flex justify-center"><svg className="animate-spin h-8 w-8 text-indigo-600" viewBox="0 0 24 24"><circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle><path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path></svg></div>
        ) : (
          <div className="overflow-x-auto">
            <table className="w-full text-left border-collapse">
              <thead className="bg-slate-50 border-b border-slate-200">
                <tr>
                  <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase">Üye Adı Soyadı</th>
                  <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase">E-posta Adresi</th>
                  <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase text-center">Aktif Ödünç / Ceza</th>
                  <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase text-right">İşlemler</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {filteredMembers.length === 0 ? (
                  <tr><td colSpan="4" className="px-6 py-8 text-center text-slate-500">Sistemde kayıtlı üye bulunamadı.</td></tr>
                ) : (
                  filteredMembers.map((member) => {
                    const fName = member.name || member.Name;
                    const sName = member.surname || member.Surname;
                    const email = member.email || member.Email;
                    const loanCount = member.loans?.length || member.Loans?.length || 0;
                    const penaltyCount = member.penalties?.length || member.Penalties?.length || 0;

                    return (
                      <tr key={member.id} className="hover:bg-slate-50 transition-colors">
                        <td className="px-6 py-4 text-sm font-semibold text-slate-900">{fName} {sName}</td>
                        <td className="px-6 py-4 text-sm text-slate-600">{email}</td>
                        <td className="px-6 py-4 text-sm text-center">
                          <div className="flex justify-center gap-2">
                            <span className="bg-blue-50 text-blue-700 px-2 py-0.5 rounded text-xs font-medium border border-blue-100">🛒 {loanCount} Ödünç</span>
                            {penaltyCount > 0 && (
                              <span className="bg-rose-50 text-rose-700 px-2 py-0.5 rounded text-xs font-medium border border-rose-100">⚠️ {penaltyCount} Ceza</span>
                            )}
                          </div>
                        </td>
                        <td className="px-6 py-4 text-sm text-right space-x-1">
                          {/* Personel ve Admin düzenleyebilir */}
                          <button onClick={() => openModal(member)} className="text-amber-600 hover:text-amber-700 hover:bg-amber-50 p-2 rounded-lg transition-colors cursor-pointer" title="Düzenle">
                            <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z"></path></svg>
                          </button>
                          
                          {(userRole === 'Admin' || userRole === 'Manager') && (
                            <button onClick={() => handleDelete(member.id)} className="text-rose-600 hover:text-rose-700 hover:bg-rose-50 p-2 rounded-lg transition-colors cursor-pointer" title="Sil">
                              <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"></path></svg>
                            </button>
                          )}
                          <button 
  onClick={() => setSelectedMemberForPenalty(member)} 
  className="text-amber-600 hover:text-amber-700 hover:bg-amber-50 p-2 rounded-lg transition-colors cursor-pointer" 
  title="Cezaları Gör"
>
  <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M3 10h18M7 15h1m4 0h1m-7 4h12a3 3 0 003-3V8a3 3 0 00-3-3H6a3 3 0 00-3 3v8a3 3 0 003 3z"></path></svg>
</button>
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

      {/* Üye Ekleme / Düzenleme Modalı */}
      {isModalOpen && (
        <div className="fixed inset-0 bg-slate-900/50 backdrop-blur-sm flex items-center justify-center z-50 p-4">
          <div className="bg-white rounded-xl shadow-2xl w-full max-w-md overflow-hidden animate-in fade-in zoom-in duration-200">
            <div className="px-6 py-4 border-b border-slate-100 flex justify-between items-center bg-slate-50">
              <h3 className="text-lg font-semibold text-slate-800">{editingMember ? 'Üye Bilgilerini Düzenle' : 'Yeni Üye Kaydı'}</h3>
              <button onClick={() => setIsModalOpen(false)} className="text-slate-400 hover:text-slate-600 cursor-pointer"><svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M6 18L18 6M6 6l12 12"></path></svg></button>
            </div>
            <form onSubmit={handleSubmit} className="p-6 space-y-4">
              {formError && <div className="bg-rose-50 text-rose-700 text-sm px-4 py-2 rounded-lg border border-rose-200">{formError}</div>}
              
              <div className="space-y-4">
                <div>
                  <label className="block text-sm font-medium text-slate-700 mb-1">Ad <span className="text-rose-500">*</span></label>
                  <input type="text" value={formData.name} onChange={(e) => setFormData({...formData, name: e.target.value})} className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" required />
                </div>
                
                <div>
                  <label className="block text-sm font-medium text-slate-700 mb-1">Soyad <span className="text-rose-500">*</span></label>
                  <input type="text" value={formData.surname} onChange={(e) => setFormData({...formData, surname: e.target.value})} className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" required />
                </div>

                <div>
                  <label className="block text-sm font-medium text-slate-700 mb-1">E-posta <span className="text-rose-500">*</span></label>
                  <input type="email" value={formData.email} onChange={(e) => setFormData({...formData, email: e.target.value})} className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" required />
                </div>

                {/* Sadece yeni üye kaydında şifre belirleme alanı gösterilir */}
                {!editingMember && (
                  <div>
                    <label className="block text-sm font-medium text-slate-700 mb-1">Geçici Giriş Şifresi</label>
                    <input type="password" value={formData.password} onChange={(e) => setFormData({...formData, password: e.target.value})} className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" placeholder="Boş bırakılırsa: Kutuphane123!" />
                  </div>
                )}
              </div>

              <div className="flex justify-end gap-3 pt-4 border-t border-slate-100 mt-4">
                <button type="button" onClick={() => setIsModalOpen(false)} className="px-4 py-2.5 border border-slate-300 text-slate-700 rounded-lg hover:bg-slate-50 transition-colors font-medium cursor-pointer">İptal</button>
                <button type="submit" className="px-6 py-2.5 bg-indigo-600 text-white rounded-lg hover:bg-indigo-700 transition-colors shadow-sm font-medium cursor-pointer">Kaydet</button>
              </div>
            </form>
          </div>
        </div>
      )}

      {selectedMemberForPenalty && (
        <PenaltyModal 
          member={selectedMemberForPenalty} 
          onClose={() => setSelectedMemberForPenalty(null)} 
          onRefresh={fetchMembers} 
        />
      )}
      
    </div>
  );
}

function PenaltyModal({ member, onClose, onRefresh }) {
  const allPenalties = member?.penalties || member?.Penalties || [];

  // 1. Aktif (Ödenmemiş) cezaları filtreleme
  const activePenalties = allPenalties.filter((p) => {
    const pIsPaid = p.isPaid !== undefined ? p.isPaid : p.IsPaid;
    return !pIsPaid;
  });

  // 2. Toplam Borç Hesaplama
  const totalDebt = activePenalties.reduce((sum, p) => {
    const pAmount = p.amount !== undefined ? p.amount : (p.Amount || 0);
    return sum + pAmount;
  }, 0);

  // Tek Bir Cezayı Ödeme Fonksiyonu
  const handlePaySingle = async (penaltyId, amount) => {
    if (!window.confirm(`${amount} TL tutarındaki bu cezayı tahsil etmek istiyor musunuz?`)) return;

    try {
      await api.post(`/api/Members/pay-penalty/${penaltyId}`);
      alert("Ceza başarıyla ödendi.");
      onRefresh();
      onClose();   
    } catch (error) {
      console.error("Ödeme hatası:", error);
      alert("Ödeme gerçekleştirilemedi.");
    }
  };

  // Toplu Ödeme Fonksiyonu 
  const handlePayAll = async () => {
    if (!window.confirm(`Üyenin toplam ${totalDebt} TL tutarındaki TÜM cezalarını topluca tahsil etmek istiyor musunuz?`)) return;

    try {
      const memberId = member?.id || member?.Id;
      await api.post(`/api/Members/pay-all/${memberId}`);
      alert("Tüm cezalar başarıyla sıfırlandı.");
      onRefresh();
      onClose();
    } catch (error) {
      console.error("Toplu ödeme hatası:", error);
      alert("Toplu ödeme gerçekleştirilemedi.");
    }
  };

  return (
    <div className="fixed inset-0 bg-slate-900/50 backdrop-blur-sm flex items-center justify-center z-50 p-4">
      <div className="bg-white rounded-xl shadow-2xl w-full max-w-md overflow-hidden animate-in fade-in zoom-in duration-200">
        
        {/* Header */}
        <div className="px-6 py-4 border-b border-slate-100 flex justify-between items-center bg-slate-50">
          <div>
            <h3 className="text-lg font-bold text-slate-800">Ceza Detayları</h3>
            <p className="text-xs text-slate-500 mt-0.5">{member?.name} {member?.surname}</p>
          </div>
          <button onClick={onClose} className="text-slate-400 hover:text-slate-600 text-xl font-bold cursor-pointer">✕</button>
        </div>

        {/* Body */}
        <div className="p-6">
          {activePenalties.length === 0 ? (
            <div className="text-center py-6">
              <span className="text-3xl">🎉</span>
              <p className="text-sm font-medium text-emerald-600 mt-2">Aktif ceza kaydı bulunmuyor.</p>
            </div>
          ) : (
            <div className="space-y-4">
              
              {/* Parça Parça Ceza Listesi */}
              <div className="max-h-56 overflow-y-auto border border-slate-100 rounded-lg bg-slate-50 divide-y divide-slate-100">
                {activePenalties.map((p, index) => {
                  const pId = p.id || p.Id;
                  const pDate = p.penaltyDate || p.PenaltyDate;
                  const pAmount = p.amount !== undefined ? p.amount : p.Amount;

                  return (
                    <div key={pId || index} className="p-3 flex justify-between items-center text-sm hover:bg-slate-100/50 transition-colors">
                      <div className="flex flex-col">
                        <span className="font-bold text-rose-600 text-base">{pAmount} TL</span>
                        <span className="text-slate-400 text-xs mt-0.5">
                          {pDate ? new Date(pDate).toLocaleDateString('tr-TR') : '-'}
                        </span>
                      </div>
                      
                      
                      <button
                        onClick={() => handlePaySingle(pId, pAmount)}
                        className="bg-white hover:bg-indigo-50 text-indigo-600 border border-indigo-200 hover:border-indigo-300 px-2.5 py-1.5 rounded-md text-xs font-semibold shadow-sm transition-all cursor-pointer"
                      >
                        Bu Cezayı Öde
                      </button>
                    </div>
                  );
                })}
              </div>

              {/* Genel Toplam ve Hepsini Öde Kartı */}
              <div className="bg-slate-50 border border-slate-200 rounded-lg p-4 flex justify-between items-center">
                <div>
                  <span className="text-xs font-semibold text-slate-500 uppercase">Genel Toplam</span>
                  <p className="text-2xl font-black text-slate-800">{totalDebt} TL</p>
                </div>
                
                {activePenalties.length > 1 && (
                  <button 
                    onClick={handlePayAll}
                    className="bg-emerald-600 hover:bg-emerald-700 text-white px-4 py-2.5 rounded-lg text-sm font-semibold shadow-sm transition-colors cursor-pointer"
                  >
                    Tümünü Öde
                  </button>
                )}
              </div>

            </div>
          )}
        </div>

        {/* Footer */}
        <div className="px-6 py-3 bg-slate-50 border-t border-slate-100 flex justify-end">
          <button onClick={onClose} className="px-4 py-2 text-sm font-medium text-slate-700 border border-slate-300 rounded-lg hover:bg-slate-100 cursor-pointer">
            Kapat
          </button>
        </div>

      </div>
    </div>
  );
}

