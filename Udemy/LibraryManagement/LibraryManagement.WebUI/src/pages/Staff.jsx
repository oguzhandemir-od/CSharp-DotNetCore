import React, { useState, useEffect } from 'react';
import api from '../api/axiosInstance'; 

export default function Staff() {
  const [staff, setStaff] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [editingStaff, setEditingStaff] = useState(null);
  const [searchQuery, setSearchQuery] = useState('');

  const [userRole, setUserRole] = useState('');
  const [isAuthorized, setIsAuthorized] = useState(true);

  const [formData, setFormData] = useState({ 
    name: '', 
    surname: '', 
    email: '', 
    password: '', 
    role: 'librarian' 
  });
  const [formError, setFormError] = useState('');

  useEffect(() => {
    const token = localStorage.getItem('library_token');
    if (token) {
      try {
        const base64Url = token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        const payload = JSON.parse(window.atob(base64));
        
        const staffType = payload.StaffType || payload.staffType || '';
      setUserRole(staffType);

        const lowerType = staffType.toLowerCase();
      if (lowerType === 'admin' || lowerType === 'manager') {
        setIsAuthorized(true);
        fetchStaff(); 
      } else {
        setIsAuthorized(false);
        setIsLoading(false);
      }
    } catch (e) {
      console.error("Token okunurken hata oluştu:", e);
      setIsAuthorized(false);
      setIsLoading(false);
    }
  } else {
    setIsAuthorized(false);
    setIsLoading(false);
  }
  }, []);

  const fetchStaff = async () => {
    setIsLoading(true);
    try {
      const response = await api.get('/Staff'); 
      setStaff(response.data || []);
    } catch (error) {
      console.error("Personel yüklenirken hata oluştu:", error);
    } finally {
      setIsLoading(false);
    }
  };

  const openModal = (person = null) => {
    setEditingStaff(person);
    if (person) {
      const nameParts = (person.fullName || person.FullName || '').split(' ');
      const surname = nameParts.length > 1 ? nameParts.pop() : '';
      const name = nameParts.join(' ');

      setFormData({
        name: name,
        surname: surname,
        email: person.email || person.Email || '',
        password: '', 
        role: person.role || 'librarian'
      });
    } else {
      setFormData({ name: '', surname: '', email: '', password: '', role: 'librarian' });
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
      if (editingStaff) {
       
        await api.put(`/Staff/${editingStaff.id || editingStaff.Id}`, {
          Name: formData.name,
          Surname: formData.surname,
          Email: formData.email
        });
      } else {
        await api.post('/Staff/register', {
          Name: formData.name,
          Surname: formData.surname,
          Email: formData.email,
          Password: formData.password || "Personel123!" 
        });
      }
      setIsModalOpen(false);
      fetchStaff();
    } catch (error) {
      console.error("Kaydetme hatası:", error);
      setFormError(error.response?.data || 'İşlem sırasında bir hata oluştu.');
    }
  };

  const handleDelete = async (id) => {
    if (!window.confirm('Bu personel hesabını tamamen silmek istediğinize emin misiniz?')) return;
    try {
      await api.delete(`/Staff/${id}`);
      fetchStaff();
    } catch (error) {
      console.error("Silme hatası:", error);
      alert(error.response?.data || 'Silme işlemi başarısız.');
    }
  };

  const filteredStaff = staff.filter(s => {
    const fullName = s.fullName || s.FullName || '';
    const email = s.email || s.Email || '';
    return fullName.toLowerCase().includes(searchQuery.toLowerCase()) || 
           email.toLowerCase().includes(searchQuery.toLowerCase());
  });

  if (!isAuthorized) {
    return (
      <div className="p-8 text-center bg-rose-50 rounded-xl border border-rose-200 max-w-xl mx-auto mt-12 shadow-sm">
        <span className="text-3xl">⚠️</span>
        <h3 className="text-lg font-bold text-rose-800 mt-2">Erişim Engellendi</h3>
        <p className="text-sm text-rose-600 mt-1">Personel Yönetimi paneline yalnızca sistem yöneticileri (Admin) erişebilir.</p>
      </div>
    );
  }

  return (
    <div className="space-y-6">
      {/* Üst Başlık */}
      <div className="flex flex-col sm:flex-row justify-between items-start sm:items-center gap-4">
        <div>
          <h2 className="text-2xl font-bold text-slate-800">Personel Yönetimi</h2>
          <p className="text-sm text-slate-500 mt-1">Sistem yöneticilerini ve kütüphanecileri ekleyin, yetkilerini yapılandırın.</p>
        </div>
        <button onClick={() => openModal()} className="bg-indigo-600 hover:bg-indigo-700 text-white px-4 py-2.5 rounded-lg flex items-center gap-2 transition-all shadow-sm hover:shadow-md font-medium cursor-pointer">
          <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 4v16m8-8H4"></path></svg>
          Yeni Personel Ekle
        </button>
      </div>

      {/* Arama Kutusu */}
      <div className="relative max-w-md">
        <svg className="absolute left-3 top-1/2 -translate-y-1/2 w-5 h-5 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"></path></svg>
        <input type="text" placeholder="Personel adı veya e-posta ile ara..." value={searchQuery} onChange={(e) => setSearchQuery(e.target.value)} className="w-full pl-10 pr-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" />
      </div>

      {/* Tablo Yapısı */}
      <div className="bg-white rounded-xl shadow-sm border border-slate-200 overflow-hidden">
        {isLoading ? (
          <div className="p-12 flex justify-center"><svg className="animate-spin h-8 w-8 text-indigo-600" viewBox="0 0 24 24"><circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle><path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path></svg></div>
        ) : (
          <table className="w-full text-left border-collapse">
            <thead className="bg-slate-50 border-b border-slate-200">
              <tr>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase">Personel Bilgisi</th>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase">E-posta</th>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase text-right">İşlemler</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {filteredStaff.length === 0 ? (
                <tr><td colSpan="3" className="px-6 py-8 text-center text-slate-500">Kayıtlı personel bulunamadı.</td></tr>
              ) : (
                filteredStaff.map((person) => {
                  const pId = person.id || person.Id;
                  const pFullName = person.fullName || person.FullName || '';
                  const pEmail = person.email || person.Email || '';

                  return (
                    <tr key={pId} className="hover:bg-slate-50 transition-colors">
                      <td className="px-6 py-4 text-sm font-semibold text-slate-900">
                        <div className="flex items-center gap-3">
                          <div className="h-8 w-8 rounded-full bg-indigo-100 text-indigo-700 flex items-center justify-center text-xs font-bold">
                            {pFullName.split(' ').map(n => n[0]).join('').substring(0, 2).toUpperCase()}
                          </div>
                          <div>{pFullName}</div>
                        </div>
                      </td>
                      <td className="px-6 py-4 text-sm text-slate-600">{pEmail}</td>
                      <td className="px-6 py-4 text-sm text-right space-x-2">
                        <button onClick={() => openModal(person)} className="text-amber-600 hover:text-amber-700 hover:bg-amber-50 p-2 rounded-lg transition-colors cursor-pointer" title="Düzenle">
                          <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z"></path></svg>
                        </button>
                        <button onClick={() => handleDelete(pId)} className="text-rose-600 hover:text-rose-700 hover:bg-rose-50 p-2 rounded-lg transition-colors cursor-pointer" title="Sil">
                          <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"></path></svg>
                        </button>
                      </td>
                    </tr>
                  );
                })
              )}
            </tbody>
          </table>
        )}
      </div>

      {/* Ekleme / Düzenleme Modalı */}
      {isModalOpen && (
        <div className="fixed inset-0 bg-slate-900/50 backdrop-blur-sm flex items-center justify-center z-50 p-4">
          <div className="bg-white rounded-xl shadow-2xl w-full max-w-md overflow-hidden animate-in fade-in zoom-in duration-200">
            <div className="px-6 py-4 border-b border-slate-100 flex justify-between items-center bg-slate-50">
              <h3 className="text-lg font-semibold text-slate-800">{editingStaff ? 'Personel Bilgilerini Düzenle' : 'Yeni Personel Ekle'}</h3>
              <button onClick={() => setIsModalOpen(false)} className="text-slate-400 hover:text-slate-600 cursor-pointer"><svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M6 18L18 6M6 6l12 12"></path></svg></button>
            </div>
            <form onSubmit={handleSubmit} className="p-6 space-y-4">
              {formError && <div className="bg-rose-50 text-rose-700 text-sm px-4 py-2 rounded-lg border border-rose-200">{formError}</div>}
              
              <div className="space-y-4">
                <div className="grid grid-cols-2 gap-3">
                  <div>
                    <label className="block text-sm font-medium text-slate-700 mb-1">Ad <span className="text-rose-500">*</span></label>
                    <input type="text" value={formData.name} onChange={(e) => setFormData({...formData, name: e.target.value})} className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" required autoFocus />
                  </div>
                  <div>
                    <label className="block text-sm font-medium text-slate-700 mb-1">Soyad <span className="text-rose-500">*</span></label>
                    <input type="text" value={formData.surname} onChange={(e) => setFormData({...formData, surname: e.target.value})} className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" required />
                  </div>
                </div>

                <div>
                  <label className="block text-sm font-medium text-slate-700 mb-1">E-posta <span className="text-rose-500">*</span></label>
                  <input type="email" value={formData.email} onChange={(e) => setFormData({...formData, email: e.target.value})} className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" required />
                </div>

                {!editingStaff && (
                  <div>
                    <label className="block text-sm font-medium text-slate-700 mb-1">Giriş Şifresi</label>
                    <input type="password" value={formData.password} onChange={(e) => setFormData({...formData, password: e.target.value})} className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" placeholder="Boş bırakılırsa: Personel123!" />
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
    </div>
  );
}