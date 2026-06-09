import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../api/axiosInstance';

export default function Catalog() {
  const navigate = useNavigate();
  const [books, setBooks] = useState([]);
  const [searchQuery, setSearchQuery] = useState('');
  const [selectedCategory, setSelectedCategory] = useState('Tüm Kategoriler');
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);

  const token = localStorage.getItem('library_token');
  const isLoggedIn = !!token;

  const fetchCatalog = async () => {
    try {
      setLoading(true);
      
      const response = await api.get('/Book');
      const catalogData = response.data || [];

      setBooks(catalogData);

      const uniqueCategories = [
        'Tüm Kategoriler',
        ...new Set(catalogData.map(b => b.categoryName ?? b.CategoryName).filter(Boolean))
      ];
      setCategories(uniqueCategories);

    } catch (err) {
      console.error("Katalog yüklenirken hata oluştu:", err);
    } finally {
      loading && setLoading(false);
    }
  };

  useEffect(() => {
    fetchCatalog();
  }, []);

  const filteredBooks = books.filter(book => {
    const matchesSearch = 
      book.name?.toLowerCase().includes(searchQuery.toLowerCase()) ||
      book.authorFullName?.toLowerCase().includes(searchQuery.toLowerCase());

    const matchesCategory = 
      selectedCategory === 'Tüm Kategoriler' || 
      (book.categoryName ?? book.CategoryName) === selectedCategory;

    return matchesSearch && matchesCategory;
  });

  return (
    <div>
      {!isLoggedIn && (
        <div className="mb-8 p-6 bg-gradient-to-r from-indigo-600 to-indigo-800 rounded-2xl text-white shadow-md relative overflow-hidden">
          <div className="relative z-10 max-w-xl">
            <h2 className="text-xl font-bold mb-2">Kütüphanemize Hoş Geldiniz!</h2>
            <p className="text-indigo-100 text-xs leading-relaxed mb-4">
              Giriş yapmadan katalogda dilediğiniz gibi arama yapabilir ve kitapların durumunu inceleyebilirsiniz. Kitap ödünç almak ve cezalarınızı takip etmek için üye girişi yapmanız gerekmektedir.
            </p>
            {/* <button 
              onClick={() => navigate('/login')}
              className="px-4 py-2 bg-white text-indigo-700 font-semibold rounded-lg text-xs hover:bg-indigo-50 transition-colors shadow-sm cursor-pointer"
            >
              Hemen Giriş Yap / Üye Ol
            </button> */}
          </div>
          <svg className="w-48 h-48 text-indigo-500/20 absolute -right-8 -bottom-8 hidden md:block" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="1.5" d="M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.747 0 3.332.477 4.5 1.253v13C19.832 18.477 18.247 18 16.5 18c-1.746 0-3.332.477-4.5 1.253"></path>
          </svg>
        </div>
      )}

      {/* Arama ve Filtreleme */}
      <div className="mb-8 flex flex-col sm:flex-row gap-4">
        <input 
          type="text" 
          value={searchQuery}
          onChange={(e) => setSearchQuery(e.target.value)}
          placeholder="Kitap veya yazar ara..." 
          className="flex-1 px-4 py-3 border border-slate-300 rounded-xl focus:ring-2 focus:ring-indigo-500 outline-none shadow-sm text-slate-800 text-sm transition-all"
        />
        <select 
          value={selectedCategory}
          onChange={(e) => setSelectedCategory(e.target.value)}
          className="px-4 py-3 border border-slate-300 rounded-xl focus:ring-2 focus:ring-indigo-500 outline-none bg-white shadow-sm text-slate-700 text-sm cursor-pointer"
        >
          {categories.map((cat, index) => (
            <option key={index} value={cat}>{cat}</option>
          ))}
        </select>
      </div>

      {loading ? (
        <div className="text-center py-12 text-slate-500 font-medium">🔄 Katalog güncelleniyor...</div>
      ) : filteredBooks.length === 0 ? (
        <div className="text-center py-12 text-slate-500 font-medium">📭 Kütüphanede böyle bir kitap bulunamadı.</div>
      ) : (
        /* Kitap Kartları Grid */
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6">
          {filteredBooks.map((book) => {
            const isAvailable = book.isAvailable;

            return (
              <div key={book.id} className="bg-white rounded-xl shadow-sm border border-slate-200 overflow-hidden hover:shadow-lg hover:-translate-y-1 transition-all duration-300 flex flex-col justify-between">
                
                <div>
                  <div className="h-48 bg-gradient-to-br from-slate-700 to-slate-900 p-6 flex flex-col justify-between text-white relative overflow-hidden border-b border-slate-100">
                    <svg className="w-32 h-32 text-white/5 absolute -right-6 -bottom-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.747 0 3.332.477 4.5 1.253v13C19.832 18.477 18.247 18 16.5 18c-1.746 0-3.332.477-4.5 1.253"></path>
                    </svg>
                    
                    <span className="text-[10px] font-bold uppercase tracking-wider bg-white/20 text-white px-2 py-1 rounded w-max backdrop-blur-xs">
                      {book.categoryName || book.CategoryName || 'Genel'}
                    </span>
                    
                    <h4 className="text-base font-bold tracking-tight line-clamp-3 mb-2 drop-shadow-sm uppercase">
                      {book.name}
                    </h4>
                  </div>
                  
                  {/* Kitap Detay Bilgileri */}
                  <div className="p-5">
                    <div className="flex justify-between items-center mb-3">
                      <span className="text-xs font-semibold text-slate-500">Durum:</span>
                      {isAvailable ? (
                        <span className="text-xs font-bold text-emerald-700 bg-emerald-50 px-2 py-0.5 rounded-md flex items-center gap-1">
                          <span className="w-1.5 h-1.5 bg-emerald-500 rounded-full"></span> Rafta / Müsait
                        </span>
                      ) : (
                        <span className="text-xs font-bold text-rose-700 bg-rose-50 px-2 py-0.5 rounded-md flex items-center gap-1">
                          <span className="w-1.5 h-1.5 bg-rose-500 rounded-full"></span> Ödünçte
                        </span>
                      )}
                    </div>
                    <h3 className="text-sm font-bold text-slate-900 mb-0.5 line-clamp-1">{book.name}</h3>
                    <p className="text-xs text-slate-500 font-medium">{book.authorFullName || 'Bilinmeyen Yazar'}</p>
                  </div>
                </div>

                <div className="px-5 pb-5 pt-0">
                  <div className={`text-center py-2 rounded-lg text-xs font-semibold select-none ${
                    isAvailable 
                      ? 'bg-slate-50 text-slate-600 border border-slate-100' 
                      : 'bg-rose-500/5 text-rose-600 border border-rose-500/10'
                  }`}>
                    {isAvailable ? '📌 Personelden talep edebilirsiniz' : '⌛ Şu an kütüphane dışındadır'}
                  </div>
                </div>

              </div>
            );
          })}
        </div>
      )}
    </div>
  );
}