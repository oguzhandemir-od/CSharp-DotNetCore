import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../api/axiosInstance'; 

export default function Login() {
  const navigate = useNavigate();
  
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleLogin = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError('');

    const endpoint = '/Auth/login/staff/';

    try {
      const response = await api.post(endpoint, {
        email: email,
        password: password
      });

      const token = response.data.token;

      localStorage.setItem('library_token', token);
      localStorage.setItem('user_role', 'staff');

      navigate('/');
      window.location.reload();

    } catch (err) {
      console.error(err);
      setError(err.response?.data || 'Personel e-posta adresi veya şifre hatalı!');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-slate-50 px-4 select-none">
      <div className="max-w-md w-full bg-white rounded-2xl shadow-xl p-8 border border-slate-100 animate-in fade-in zoom-in-95 duration-200">
        
        {/* Logo / Başlık Alanı */}
        <div className="text-center mb-6">
          <div className="mx-auto h-12 w-12 bg-indigo-700 rounded-xl flex items-center justify-center mb-4 shadow-md shadow-indigo-200">
            <svg className="w-7 h-7 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M21 13.255A23.931 23.931 0 0112 15c-3.183 0-6.22-.62-9-1.745M16 6V4a2 2 0 00-2-2h-4a2 2 0 00-2 2v2m4 6h.01M5 20h14a2 2 0 002-2V8a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z"></path>
            </svg>
          </div>
          <h2 className="text-2xl font-bold text-slate-800">Personel Yönetim Paneli</h2>
          <p className="text-slate-500 mt-1 text-xs">Kütüphane personeli ve yönetim girişi</p>
        </div>

        {/* Hata Mesajı Alanı */}
        {error && (
          <div className="mb-4 p-3 bg-rose-50 border border-rose-100 text-rose-600 text-xs rounded-xl text-center font-medium">
            ⚠️ {error}
          </div>
        )}

        {/* Form Alanı */}
        <form onSubmit={handleLogin} className="space-y-4">
          <div>
            <label className="block text-xs font-semibold text-slate-600 mb-1">Kurumsal E-posta</label>
            <input 
              type="email" 
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              className="w-full px-4 py-2.5 border border-slate-200 rounded-xl focus:ring-2 focus:ring-indigo-500 outline-none transition-all text-slate-800 text-sm"
              placeholder="personel@kutuphane.com"
              required
            />
          </div>
          <div>
            <label className="block text-xs font-semibold text-slate-600 mb-1">Şifre</label>
            <input 
              type="password" 
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="w-full px-4 py-2.5 border border-slate-200 rounded-xl focus:ring-2 focus:ring-indigo-500 outline-none transition-all text-slate-800 text-sm"
              placeholder="••••••••"
              required
            />
          </div>
          
          <div className="flex items-center justify-between text-xs pt-1">
            <label className="flex items-center text-slate-500 cursor-pointer">
              <input type="checkbox" className="mr-2 rounded border-slate-300 text-indigo-600 focus:ring-indigo-500" />
              Beni hatırla
            </label>
            <a href="#" className="text-indigo-600 hover:text-indigo-800 font-semibold">Şifremi unuttum</a>
          </div>

          <button 
            type="submit" 
            disabled={loading}
            className="w-full bg-indigo-600 hover:bg-indigo-700 text-white font-semibold py-3 rounded-xl transition-colors shadow-sm cursor-pointer disabled:bg-indigo-400 disabled:cursor-not-allowed text-sm mt-2"
          >
            {loading ? '⏱️ Kimlik Doğrulanıyor...' : 'Sisteme Giriş Yap'}
          </button>
        </form>

      </div>
    </div>
  );
}