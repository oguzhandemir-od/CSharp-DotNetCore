import React, { useState, useEffect } from 'react';
import api from '../api/axiosInstance'; 

export default function Authors() {
  const [authors, setAuthors] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [editingAuthor, setEditingAuthor] = useState(null);
  const [isManager, setIsManager] = useState(false); 

  const [formData, setFormData] = useState({ Name: '', Surname: '', Detail: '' });
  const [formError, setFormError] = useState('');

  

  const fetchAuthors = async () => {
    setIsLoading(true);
    try {
      const response = await api.get('/Author'); 
      setAuthors(response.data || []);
    } catch (error) {
      console.error("Yazarlar yüklenirken hata oluştu:", error);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    fetchAuthors();
  }, []);

  const openModal = (author = null) => {
    setEditingAuthor(author);
    if (author) {
      setFormData({
        Name: author.name ?? author.Name ?? '',
        Surname: author.surname ?? author.Surname ?? '',
        Detail: author.detail ?? author.Detail ?? ''
      });
    } else {
      setFormData({ Name: '', Surname: '', Detail: '' });
    }
    setFormError('');
    setIsModalOpen(true);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!formData.Name.trim() || !formData.Surname.trim()) {
      setFormError('Yazar adı ve soyadı zorunludur.');
      return;
    }

    try {
      const payload = {
        Name: formData.Name,
        Surname: formData.Surname,
        Detail: formData.Detail
      };

      if (editingAuthor) {
        await api.put(`/Author/${editingAuthor.id}`, payload);
      } else {
        await api.post('/Author', payload);
      }
      
      setIsModalOpen(false);
      fetchAuthors(); 
    } catch (error) {
      console.error("Kaydetme hatası:", error);
      setFormError(error.response?.data || 'Kaydedilirken bir hata oluştu.');
    }
  };

  const handleDelete = async (id) => {
    if (!window.confirm('Bu yazarı silmek istediğinize emin misiniz?')) return;

    try {
      await api.delete(`/Author/${id}`);
      setAuthors(prev => prev.filter(a => a.id !== id));
    } catch (error) {
      console.error("Silme hatası:", error);
      alert(error.response?.data || 'Yazar silinirken bir hata oluştu. Muhtemelen ilişkili kitapları var.');
    }
  };

  return (
    <div className="space-y-6">
      {/* Üst Başlık ve Aksiyonlar */}
      <div className="flex flex-col sm:flex-row justify-between items-start sm:items-center gap-4">
        <div>
          <h2 className="text-2xl font-bold text-slate-800">Yazar Yönetimi</h2>
          <p className="text-sm text-slate-500 mt-1">Kütüphane envanterindeki yazar bilgilerini buradan yönetebilirsiniz.</p>
        </div>
        <button 
          onClick={() => openModal()}
          className="bg-indigo-600 hover:bg-indigo-700 text-white px-4 py-2.5 rounded-lg flex items-center gap-2 transition-all shadow-sm hover:shadow-md font-medium cursor-pointer"
        >
          <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 4v16m8-8H4"></path></svg>
          Yeni Yazar Ekle
        </button>
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
          <table className="w-full text-left border-collapse">
            <thead className="bg-slate-50 border-b border-slate-200">
              <tr>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Adı</th>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Soyadı</th>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Detay / Biyografi</th>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider text-center">Eser Sayısı</th>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider text-right">İşlemler</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {authors.length === 0 ? (
                <tr><td colSpan="5" className="px-6 py-8 text-center text-slate-500">Henüz yazar bulunmamaktadır.</td></tr>
              ) : (
                authors.map((author) => {
                  const name = author.name ?? author.Name;
                  const surname = author.surname ?? author.Surname;
                  const detail = author.detail ?? author.Detail;
                  const bookCount = author.books?.length ?? author.Books?.length ?? 0;

                  return (
                    <tr key={author.id} className="hover:bg-slate-50 transition-colors">
                      <td className="px-6 py-4 text-sm font-semibold text-slate-900">{name}</td>
                      <td className="px-6 py-4 text-sm font-semibold text-slate-900">{surname}</td>
                      <td className="px-6 py-4 text-sm text-slate-600 max-w-xs truncate">{detail || 'Bilgi yok'}</td>
                      <td className="px-6 py-4 text-sm text-slate-600 text-center">
                        <span className="bg-indigo-50 text-indigo-700 px-2.5 py-1 rounded-full text-xs font-semibold">{bookCount} Eser</span>
                      </td>
                      <td className="px-6 py-4 text-sm text-right space-x-2">
                        <button onClick={() => openModal(author)} className="text-amber-600 hover:text-amber-700 hover:bg-amber-50 p-2 rounded-lg transition-colors cursor-pointer" title="Düzenle">
                          <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z"></path></svg>
                        </button>
                        
                        
                          <button onClick={() => handleDelete(author.id)} className="text-rose-600 hover:text-rose-700 hover:bg-rose-50 p-2 rounded-lg transition-colors cursor-pointer" title="Sil">
                            <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"></path></svg>
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
          <div className="bg-white rounded-xl shadow-2xl w-full max-w-lg overflow-hidden animate-in fade-in zoom-in duration-200">
            <div className="px-6 py-4 border-b border-slate-100 flex justify-between items-center bg-slate-50">
              <h3 className="text-lg font-semibold text-slate-800">{editingAuthor ? 'Yazarı Düzenle' : 'Yeni Yazar Ekle'}</h3>
              <button onClick={() => setIsModalOpen(false)} className="text-slate-400 hover:text-slate-600 transition-colors cursor-pointer">
                <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M6 18L18 6M6 6l12 12"></path></svg>
              </button>
            </div>
            <form onSubmit={handleSubmit} className="p-6 space-y-4">
              {formError && (
                <div className="bg-rose-50 text-rose-700 text-sm px-4 py-2 rounded-lg border border-rose-200 flex items-center gap-2">
                  <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 8v4m0 4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path></svg>
                  {formError}
                </div>
              )}
              <div className="grid grid-cols-2 gap-4">
                <div>
                  <label className="block text-sm font-medium text-slate-700 mb-1">Adı <span className="text-rose-500">*</span></label>
                  <input 
                    type="text" 
                    value={formData.Name}
                    onChange={(e) => setFormData({...formData, Name: e.target.value})}
                    className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500 outline-none transition-all text-sm font-medium text-slate-800"
                    placeholder="Örn: Fyodor"
                    autoFocus
                  />
                </div>
                <div>
                  <label className="block text-sm font-medium text-slate-700 mb-1">Soyadı <span className="text-rose-500">*</span></label>
                  <input 
                    type="text" 
                    value={formData.Surname}
                    onChange={(e) => setFormData({...formData, Surname: e.target.value})}
                    className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500 outline-none transition-all text-sm font-medium text-slate-800"
                    placeholder="Örn: Dostoyevski"
                  />
                </div>
              </div>
              <div>
                <label className="block text-sm font-medium text-slate-700 mb-1">Yazar Detayı / Biyografi</label>
                <textarea 
                  value={formData.Detail}
                  onChange={(e) => setFormData({...formData, Detail: e.target.value})}
                  rows="4"
                  className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500 outline-none transition-all resize-none text-sm font-medium text-slate-800"
                  placeholder="Yazar hakkında detaylı bilgi, yüzyılı veya edebi akımı..."
                ></textarea>
              </div>
              <div className="flex justify-end gap-3 pt-2">
                <button type="button" onClick={() => setIsModalOpen(false)} className="px-4 py-2.5 border border-slate-300 text-slate-700 rounded-lg hover:bg-slate-50 transition-colors font-medium cursor-pointer">
                  İptal
                </button>
                <button type="submit" className="px-6 py-2.5 bg-indigo-600 text-white rounded-lg hover:bg-indigo-700 transition-colors shadow-sm font-medium flex items-center gap-2 cursor-pointer">
                  Kaydet
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
}