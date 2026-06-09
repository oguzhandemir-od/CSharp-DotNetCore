import React, { useState } from 'react';
import api from '../api/axiosInstance';

export default function AuthModal({ isOpen, onClose }) {
  const [isLoginMode, setIsLoginMode] = useState(true);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const [formData, setFormData] = useState({
    name: '',
    surname: '',
    email: '',
    password: ''
  });

  if (!isOpen) return null;

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
  e.preventDefault();
  setLoading(true);
  setError('');

  try {
    if (isLoginMode) {
  const response = await api.post('/Auth/login/member', {
    email: formData.email,
    password: formData.password
  });
  
  const token = response.data.token || response.data.Token;
  
  localStorage.setItem('library_token', token);
  
  localStorage.setItem('user_role', 'member'); 
  
  window.location.reload(); 
} 
     else {
      await api.post('/Auth/register/member', {
        name: formData.name,
        surname: formData.surname,
        email: formData.email,
        password: formData.password
      });
      
      alert("Üye kaydı başarıyla tamamlandı! Şimdi giriş yapabilirsiniz.");
      setIsLoginMode(true);
    }
  } catch (err) {
    setError(err.response?.data || 'Bir hata oluştu, lütfen bilgilerinizi kontrol edin.');
  } finally {
    setLoading(false);
  }
};

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center select-none">
      <div className="absolute inset-0 bg-slate-900/40 backdrop-blur-xs" onClick={onClose}></div>

      {/* Modal Kutusu */}
      <div className="bg-white w-full max-w-md rounded-2xl shadow-xl border border-slate-100 z-10 overflow-hidden relative mx-4 animate-in fade-in zoom-in-95 duration-200">
        
        <button onClick={onClose} className="absolute right-4 top-4 text-slate-400 hover:text-slate-600 cursor-pointer">
          <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M6 18L18 6M6 6l12 12"></path>
          </svg>
        </button>

        <div className="p-8">
          {/* Başlık alanı */}
          <div className="text-center mb-6">
            <h3 className="text-xl font-bold text-slate-800">
              {isLoginMode ? 'Kütüphaneye Giriş Yap' : 'Yeni Üye Kaydı'}
            </h3>
            <p className="text-xs text-slate-500 mt-1">
              {isLoginMode ? 'Hesabınıza erişerek kitap işlemlerinizi yönetin' : 'Katalogdan kitap talep etmek için hemen üye olun'}
            </p>
          </div>

          {error && (
            <div className="mb-4 p-3 bg-rose-50 border border-rose-100 text-rose-600 rounded-xl text-xs font-medium text-center">
              ⚠️ {error}
            </div>
          )}

          {/* Form */}
          <form onSubmit={handleSubmit} className="space-y-4">
            {!isLoginMode && (
              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="block text-xs font-semibold text-slate-600 mb-1">Adınız</label>
                  <input type="text" name="name" required value={formData.name} onChange={handleChange} className="w-full px-3 py-2.5 border border-slate-200 rounded-xl text-sm focus:ring-2 focus:ring-indigo-500 outline-none" />
                </div>
                <div>
                  <label className="block text-xs font-semibold text-slate-600 mb-1">Soyadınız</label>
                  <input type="text" name="surname" required value={formData.surname} onChange={handleChange} className="w-full px-3 py-2.5 border border-slate-200 rounded-xl text-sm focus:ring-2 focus:ring-indigo-500 outline-none" />
                </div>
              </div>
            )}

            <div>
              <label className="block text-xs font-semibold text-slate-600 mb-1">E-Posta Adresi</label>
              <input type="email" name="email" required value={formData.email} onChange={handleChange} placeholder="ornek@mail.com" className="w-full px-3 py-2.5 border border-slate-200 rounded-xl text-sm focus:ring-2 focus:ring-indigo-500 outline-none" />
            </div>

            <div>
              <label className="block text-xs font-semibold text-slate-600 mb-1">Şifre</label>
              <input type="password" name="password" required value={formData.password} onChange={handleChange} placeholder="••••••••" className="w-full px-3 py-2.5 border border-slate-200 rounded-xl text-sm focus:ring-2 focus:ring-indigo-500 outline-none" />
            </div>

            <button type="submit" disabled={loading} className="w-full py-3 bg-indigo-600 hover:bg-indigo-700 text-white rounded-xl text-sm font-semibold shadow-sm transition-colors cursor-pointer disabled:bg-indigo-400">
              {loading ? '⏱️ İşlem yapılıyor...' : isLoginMode ? 'Giriş Yap' : 'Kayıt Ol'}
            </button>
          </form>

          {/* Modlar Arası Geçiş Linki */}
          <div className="mt-6 text-center border-t border-slate-100 pt-4">
            <p className="text-xs text-slate-500">
              {isLoginMode ? 'Henüz üye değil misiniz?' : 'Zaten hesabınız var mı?'}
              <button 
                type="button" 
                onClick={() => { setIsLoginMode(!isLoginMode); setError(''); }} 
                className="text-indigo-600 font-bold ml-1 hover:underline cursor-pointer"
              >
                {isLoginMode ? 'Üye Olun' : 'Giriş Yapın'}
              </button>
            </p>
          </div>

        </div>
      </div>
    </div>
  );
}