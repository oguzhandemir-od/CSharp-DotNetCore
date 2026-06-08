import React, { useState } from 'react';
import api from '../api/axiosInstance'; 

export default function Login() {
  // 1. Form state'leri
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [role, setRole] = useState('member'); 
  
  // 2. Durum state'leri
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleLogin = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError('');

    const endpoint = role === 'member' ? '/Auth/login/member' : '/Auth/login/staff';

    try {
      const response = await api.post(endpoint, {
        email: email,
        password: password
      });

      const token = response.data.token;

      localStorage.setItem('library_token', token);
      
      localStorage.setItem('user_role', role);

      window.location.reload();

    } catch (err) {
      console.error(err);
      setError(err.response?.data || 'E-posta adresi veya şifre hatalı!');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-slate-50 px-4">
      <div className="max-w-md w-full bg-white rounded-2xl shadow-xl p-8 border border-slate-100">
        
        {/* Logo / Başlık Alanı */}
        <div className="text-center mb-6">
          <div className="mx-auto h-12 w-12 bg-indigo-600 rounded-xl flex items-center justify-center mb-4">
            <svg className="w-7 h-7 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.747 0 3.332.477 4.5 1.253v13C19.832 18.477 18.247 18 16.5 18c-1.746 0-3.332.477-4.5 1.253"></path>
            </svg>
          </div>
          <h2 className="text-2xl font-bold text-slate-800">Kütüphane Yönetim Sistemi</h2>
          <p className="text-slate-500 mt-2 text-sm">Devam etmek için hesabınıza giriş yapın.</p>
        </div>

        {/* Hata Mesajı Alanı */}
        {error && (
          <div className="mb-4 p-3 bg-red-50 border border-red-200 text-red-600 text-sm rounded-lg text-center font-medium">
            ⚠️ {error}
          </div>
        )}

        {/* Rol Seçim Sekmeleri (Tabs) */}
        <div className="flex bg-slate-100 p-1 rounded-xl mb-6">
          <button
            type="button"
            onClick={() => setRole('member')}
            className={`flex-1 py-2 text-sm font-semibold rounded-lg transition-all ${role === 'member' ? 'bg-white text-indigo-600 shadow-sm' : 'text-slate-600 hover:text-slate-900'}`}
          >
            👤 Üye Girişi
          </button>
          <button
            type="button"
            onClick={() => setRole('staff')}
            className={`flex-1 py-2 text-sm font-semibold rounded-lg transition-all ${role === 'staff' ? 'bg-white text-indigo-600 shadow-sm' : 'text-slate-600 hover:text-slate-900'}`}
          >
            💼 Personel Girişi
          </button>
        </div>

        {/* Form Alanı */}
        <form onSubmit={handleLogin} className="space-y-5">
          <div>
            <label className="block text-sm font-medium text-slate-700 mb-1">E-posta Adresi</label>
            <input 
              type="email" 
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500 outline-none transition-all text-slate-800"
              placeholder="ornek@kurum.com"
              required
            />
          </div>
          <div>
            <label className="block text-sm font-medium text-slate-700 mb-1">Şifre</label>
            <input 
              type="password" 
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="w-full px-4 py-2.5 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500 outline-none transition-all text-slate-800"
              placeholder="••••••••"
              required
            />
          </div>
          
          <div className="flex items-center justify-between text-sm">
            <label className="flex items-center text-slate-600 cursor-pointer">
              <input type="checkbox" className="mr-2 rounded border-slate-300 text-indigo-600 focus:ring-indigo-500" />
              Beni hatırla
            </label>
            <a href="#" className="text-indigo-600 hover:text-indigo-800 font-medium">Şifremi unuttum</a>
          </div>

          <button 
            type="submit" 
            disabled={loading}
            className="w-full bg-indigo-600 hover:bg-indigo-700 text-white font-semibold py-2.5 rounded-lg transition-colors shadow-md hover:shadow-lg disabled:bg-indigo-400 disabled:cursor-not-allowed"
          >
            {loading ? 'Kontrol Ediliyor...' : 'Giriş Yap'}
          </button>
        </form>

      </div>
    </div>
  );
}