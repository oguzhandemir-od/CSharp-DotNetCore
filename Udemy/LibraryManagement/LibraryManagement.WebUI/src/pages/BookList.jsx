import React, { useState, useEffect } from 'react';
import { useLocation } from 'react-router-dom'; 
import api from '../api/axiosInstance';

export default function BookList() {
  const [books, setBooks] = useState([]);
  const [searchQuery, setSearchQuery] = useState('');
  const [loading, setLoading] = useState(true);

  const location = useLocation(); 
  
  const initialCategory = location.state?.selectedCategory ?? '';
  const [categoryFilter, setCategoryFilter] = useState(initialCategory);

  const [isModalOpen, setIsModalOpen] = useState(false);
  const [editingBookId, setEditingBookId] = useState(null); 
  
  const [formData, setFormData] = useState({
    name: '',
    authorFullName: '', 
    categoryName: '', 
    publisher: '',
    publicationYear:'',
    pageCount:''
  });

  useEffect(() => {
    if (location.state?.selectedCategory) {
      window.history.replaceState({}, document.title);
    }
  }, [location]);

  const fetchBooks = async () => {
    try {
      setLoading(true);
      const response = await api.get('/Book'); 
      setBooks(response.data || []);
    } catch (err) {
      console.error("Kitaplar yüklenirken hata oluştu:", err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchBooks();
  }, []);

  const handleDelete = async (id) => {
    if (window.confirm("Bu kitabı silmek istediğinize emin misiniz?")) {
      try {
        await api.delete(`/Book/${id}`);
        setBooks(books.filter(book => book.id !== id));
      } catch (err) {
        console.error("Kitap silinemedi:", err);
        alert("Kitap silinirken bir hata oluştu!");
      }
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      if (editingBookId) {
        await api.put(`/Book/${editingBookId}`, formData);
      } else {
        await api.post('/Book', formData);
      }
      
      closeModal();
      fetchBooks();
    } catch (err) {
      console.error("Form gönderilirken hata oluştu:", err);
      alert("İşlem başarısız! Lütfen alanları kontrol edin.");
    }
  };

  const openAddModal = () => {
    setEditingBookId(null);
    setFormData({ name: '', authorFullName: '', categoryName: '', publisher: '', publicationYear: 1900, pageCount: 0 });
    setIsModalOpen(true);
  };

  const openEditModal = (book) => {
    setEditingBookId(book.id);
    setFormData({
      name: book.name,
      authorFullName: book.authorFullName || '',
      categoryName: book.categoryName || '',
      publisher: book.publisher || '',
      publicationYear: book.publicationYear || 1900,
      pageCount: book.pageCount || 0
    });
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setIsModalOpen(false);
    setEditingBookId(null);
  };

  const filteredBooks = books.filter(book => {
    const bookName = book.name ?? book.Name ?? '';
    const bookAuthor = book.authorFullName ?? book.AuthorFullName ?? '';
    const bookPublisher = book.publisher ?? book.Publisher ?? '';
    const bookCategory = book.categoryName ?? book.CategoryName ?? '';

    const matchesCategory = categoryFilter === '' || bookCategory.toLowerCase() === categoryFilter.toLowerCase();
    
    const matchesSearch = 
      bookName.toLowerCase().includes(searchQuery.toLowerCase()) ||
      bookAuthor.toLowerCase().includes(searchQuery.toLowerCase()) ||
      bookPublisher.toLowerCase().includes(searchQuery.toLowerCase());

    return matchesCategory && matchesSearch;
  });

  return (
    <div className="space-y-6">
      
      {/* Tablo Üst Kontroller */}
      <div className="flex flex-col sm:flex-row justify-between items-start sm:items-center gap-4">
        <div className="flex flex-col gap-2 w-full sm:w-auto">
          <div className="relative w-full sm:w-80">
            <svg className="absolute left-3 top-1/2 -translate-y-1/2 w-5 h-5 text-slate-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"></path>
            </svg>
            <input 
              type="text" 
              value={searchQuery}
              onChange={(e) => setSearchQuery(e.target.value)}
              placeholder="Kitap adı, yazar veya yayınevi ara..." 
              className="w-full pl-10 pr-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500 outline-none transition-all text-slate-800 text-sm font-medium"
            />
          </div>

          {categoryFilter && (
            <div className="flex items-center gap-2 animate-in slide-in-from-left-2 duration-150">
              <span className="text-xs bg-indigo-50 text-indigo-700 border border-indigo-200 px-2.5 py-1 rounded-md font-bold flex items-center gap-1.5 shadow-2xs uppercase tracking-wider">
                📁 Kategori: {categoryFilter}
                <button 
                  onClick={() => setCategoryFilter('')}
                  className="hover:bg-indigo-200 text-indigo-900 rounded-full w-4 h-4 inline-flex items-center justify-center font-black cursor-pointer transition-colors"
                  title="Filtreyi Temizle"
                >
                  ×
                </button>
              </span>
            </div>
          )}
        </div>

        <button 
          onClick={openAddModal}
          className="bg-indigo-600 hover:bg-indigo-700 text-white px-4 py-2 rounded-lg flex items-center gap-2 transition-colors shadow-sm text-sm font-semibold cursor-pointer whitespace-nowrap"
        >
          <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 4v16m8-8H4"></path>
          </svg>
          Yeni Kitap Ekle
        </button>
      </div>

      {/* Veri Tablosu */}
      <div className="bg-white rounded-xl shadow-sm border border-slate-200 overflow-hidden">
        {loading ? (
          <div className="p-12 flex justify-center items-center text-slate-400">
            <svg className="animate-spin h-8 w-8 text-indigo-600" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
              <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
              <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
            </svg>
          </div>
        ) : filteredBooks.length === 0 ? (
          <div className="p-12 text-center text-slate-400 font-medium border-dashed border-2 border-slate-100 m-4 rounded-xl">
            📭 Aradığınız kriterlere uygun kitap bulunamadı.
          </div>
        ) : (
          <table className="w-full text-left border-collapse">
            <thead className="bg-slate-50 border-b border-slate-200">
              <tr>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Kitap Adı</th>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Yazar</th>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Kategori</th>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Yayınevi</th>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Basım Yılı</th>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">Sayfa Sayısı</th>
                <th className="px-6 py-4 text-xs font-semibold text-slate-500 uppercase tracking-wider text-right">İşlemler</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {filteredBooks.map((book) => {
                const id = book.id ?? book.Id;
                const name = book.name ?? book.Name;
                const authorFullName = book.authorFullName ?? book.AuthorFullName ?? 'Belirtilmemiş';
                const categoryName = book.categoryName ?? book.CategoryName ?? 'Genel';
                const publisher = book.publisher ?? book.Publisher;
                const publicationYear = book.publicationYear ?? book.PublicationYear;
                const pageCount = book.pageCount ?? book.PageCount;

                return (
                  <tr key={id} className="hover:bg-slate-50/80 transition-colors">
                    <td className="px-6 py-4 text-sm font-semibold text-slate-900">{name}</td>
                    <td className="px-6 py-4 text-sm text-slate-600">{authorFullName}</td>
                    <td className="px-6 py-4 text-sm text-slate-600">
                      <span className="bg-slate-100 text-slate-700 px-2 py-1 rounded-md text-xs font-bold uppercase tracking-wider">
                        {categoryName}
                      </span>
                    </td>
                    <td className="px-6 py-4 text-sm text-slate-600">{publisher}</td>
                    <td className="px-6 py-4 text-sm text-slate-600">{publicationYear}</td>
                    <td className="px-6 py-4 text-sm text-slate-600">{pageCount}</td>
                    <td className="px-6 py-4 text-sm text-right space-x-2 whitespace-nowrap">
                      <button 
                        onClick={() => openEditModal(book)}
                        className="bg-amber-500 hover:bg-amber-600 text-white px-3 py-1.5 rounded-md text-xs font-semibold transition-colors inline-flex items-center gap-1 cursor-pointer"
                      >
                        <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z"></path>
                        </svg>
                        Düzenle
                      </button>
                      <button 
                        onClick={() => handleDelete(id)}
                        className="bg-rose-500 hover:bg-rose-600 text-white px-3 py-1.5 rounded-md text-xs font-semibold transition-colors inline-flex items-center gap-1 cursor-pointer"
                      >
                        <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"></path>
                        </svg>
                        Sil
                      </button>
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        )}
      </div>

      {/* --- AÇILIR MODAL FORM TASARIMI --- */}
      {isModalOpen && (
        <div className="fixed inset-0 bg-slate-900/40 backdrop-blur-sm flex items-center justify-center p-4 z-50 animate-fade-in">
          <div className="bg-white p-6 rounded-xl shadow-xl border border-slate-200 max-w-2xl w-full">
            <h3 className="text-lg font-bold text-slate-800 mb-4 border-b border-slate-100 pb-2">
              {editingBookId ? '📚 Kitap Bilgilerini Düzenle' : '✨ Yeni Kitap Ekle'}
            </h3>
            <form onSubmit={handleSubmit} className="grid grid-cols-1 md:grid-cols-2 gap-4">
              <div>
                <label className="block text-sm font-medium text-slate-700 mb-1">Kitap Adı</label>
                <input 
                  type="text" 
                  value={formData.name}
                  onChange={(e) => setFormData({...formData, name: e.target.value})}
                  className="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-slate-800 text-sm font-medium" 
                  required
                />
              </div>
              <div>
                <label className="block text-sm font-medium text-slate-700 mb-1">Yazar</label>
                <input 
                  type="text" 
                  value={formData.authorFullName}
                  onChange={(e) => setFormData({...formData, authorFullName: e.target.value})}
                  className="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-slate-800 text-sm font-medium" 
                  placeholder="Yazar adı"
                />
              </div>
              <div>
                <label className="block text-sm font-medium text-slate-700 mb-1">Kategori</label>
                <input 
                  type="text" 
                  value={formData.categoryName}
                  onChange={(e) => setFormData({...formData, categoryName: e.target.value})}
                  className="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-slate-800 text-sm font-medium" 
                  placeholder="Kategori adı"
                />
              </div>
              <div>
                <label className="block text-sm font-medium text-slate-700 mb-1">Yayınevi</label>
                <input 
                  type="text" 
                  value={formData.publisher}
                  onChange={(e) => setFormData({...formData, publisher: e.target.value})}
                  className="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-slate-800 text-sm font-medium" 
                  required
                />
              </div>
              <div>
                <label className="block text-sm font-medium text-slate-700 mb-1">Basım Yılı</label>
                <input 
                  type="text" 
                  value={formData.publicationYear}
                  onChange={(e) => setFormData({...formData, publicationYear: e.target.value})}
                  className="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-slate-800 text-sm font-medium" 
                />
              </div>
              <div>
                <label className="block text-sm font-medium text-slate-700 mb-1">Sayfa Sayısı</label>
                <input 
                  type="text" 
                  value={formData.pageCount}
                  onChange={(e) => setFormData({...formData, pageCount: e.target.value})}
                  className="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-slate-800 text-sm font-medium" 
                  required
                />
              </div>
              
              <div className="md:col-span-2 flex justify-end gap-3 mt-4 border-t border-slate-100 pt-4">
                <button 
                  type="button" 
                  onClick={closeModal}
                  className="px-4 py-2 border border-slate-300 text-slate-700 rounded-lg hover:bg-slate-50 transition-colors text-sm font-semibold cursor-pointer"
                >
                  İptal
                </button>
                <button 
                  type="submit" 
                  className="px-6 py-2 bg-indigo-600 text-white rounded-lg hover:bg-indigo-700 transition-colors shadow-sm text-sm font-semibold cursor-pointer"
                >
                  {editingBookId ? 'Değişiklikleri Kaydet' : 'Kitabı Kaydet'}
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
}