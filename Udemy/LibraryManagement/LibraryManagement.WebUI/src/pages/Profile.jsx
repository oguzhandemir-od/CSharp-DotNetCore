import React, { useState, useEffect } from 'react';
import api from '../api/axiosInstance';

export default function Profile() {
  const [profileData, setProfileData] = useState({ Name: '', Surname: '', Email: '' });
  
  const [passwordData, setPasswordData] = useState({ OldPassword: '', NewPassword: '', confirmPassword: '' });
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const response = await api.get('/Member/profile'); 
        setProfileData({
          Name: response.data.name ?? response.data.Name ?? '',
          Surname: response.data.surname ?? response.data.Surname ?? '',
          Email: response.data.email ?? response.data.Email ?? ''
        });
      } catch (err) {
        console.error("Profil bilgileri çekilemedi:", err);
      } finally {
        setLoading(false);
      }
    };
    fetchProfile();
  }, []);

  const handleProfileSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.put('/Member/update-profile', profileData);
      alert("Kişisel bilgileriniz başarıyla güncellendi!");
    } catch (err) {
      alert("Güncelleme başarısız: " + (err.response?.data || "Bir hata oluştu"));
    }
  };

  const handlePasswordSubmit = async (e) => {
    e.preventDefault();
    
    if (passwordData.NewPassword !== passwordData.confirmPassword) {
      alert("Yeni şifreler birbiriyle uyuşmuyor!");
      return;
    }

    try {
      await api.post('/Member/change-password', {
        OldPassword: passwordData.OldPassword,
        NewPassword: passwordData.NewPassword
      });
      alert("Şifreniz başarıyla değiştirildi!");
      setPasswordData({ OldPassword: '', NewPassword: '', confirmPassword: '' });
    } catch (err) {
      alert("Şifre değiştirilemedi: " + (err.response?.data || "Mevcut şifreniz hatalı"));
    }
  };

  if (loading) return <div className="text-center py-12 text-slate-500 font-medium">🔄 Profil yükleniyor...</div>;

  return (
    <div className="grid grid-cols-1 lg:grid-cols-2 gap-8">
      {/* Kişisel Bilgiler Formu */}
      <div className="bg-white p-6 rounded-xl shadow-sm border border-slate-200">
        <h3 className="text-lg font-bold text-slate-800 mb-4">Kişisel Bilgilerim</h3>
        <form onSubmit={handleProfileSubmit} className="space-y-4">
          <div className="grid grid-cols-2 gap-4">
            <div>
              <label className="block text-xs font-semibold text-slate-600 mb-1">Ad</label>
              <input 
                type="text" 
                value={profileData.Name} 
                onChange={(e) => setProfileData({...profileData, Name: e.target.value})}
                className="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm text-slate-800 font-medium" 
              />
            </div>
            <div>
              <label className="block text-xs font-semibold text-slate-600 mb-1">Soyad</label>
              <input 
                type="text" 
                value={profileData.Surname} 
                onChange={(e) => setProfileData({...profileData, Surname: e.target.value})}
                className="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm text-slate-800 font-medium" 
              />
            </div>
          </div>
          <div>
            <label className="block text-xs font-semibold text-slate-600 mb-1">E-posta</label>
            <input 
              type="email" 
              disabled
              value={profileData.Email} 
              className="w-full px-4 py-2 border border-slate-200 bg-slate-50 text-slate-400 rounded-lg outline-none text-sm cursor-not-allowed font-medium" 
            />
          </div>
          <button type="submit" className="w-full bg-indigo-600 text-white py-2 rounded-lg hover:bg-indigo-700 transition-colors font-semibold text-sm cursor-pointer shadow-xs">Bilgileri Güncelle</button>
        </form>
      </div>

      {/* Şifre Değiştirme Formu */}
      <div className="bg-white p-6 rounded-xl shadow-sm border border-slate-200">
        <h3 className="text-lg font-bold text-slate-800 mb-4">Şifre Değiştir</h3>
        <form onSubmit={handlePasswordSubmit} className="space-y-4">
          <div>
            <label className="block text-xs font-semibold text-slate-600 mb-1">Mevcut Şifre</label>
            <input 
              type="password" 
              value={passwordData.OldPassword}
              onChange={(e) => setPasswordData({...passwordData, OldPassword: e.target.value})}
              className="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" 
            />
          </div>
          <div>
            <label className="block text-xs font-semibold text-slate-600 mb-1">Yeni Şifre</label>
            <input 
              type="password" 
              value={passwordData.NewPassword}
              onChange={(e) => setPasswordData({...passwordData, NewPassword: e.target.value})}
              className="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" 
            />
          </div>
          <div>
            <label className="block text-xs font-semibold text-slate-600 mb-1">Yeni Şifre (Tekrar)</label>
            <input 
              type="password" 
              value={passwordData.confirmPassword}
              onChange={(e) => setPasswordData({...passwordData, confirmPassword: e.target.value})}
              className="w-full px-4 py-2 border border-slate-300 rounded-lg focus:ring-2 focus:ring-indigo-500 outline-none text-sm" 
            />
          </div>
          <button type="submit" className="w-full bg-slate-800 text-white py-2 rounded-lg hover:bg-slate-900 transition-colors font-semibold text-sm cursor-pointer shadow-xs">Şifreyi Güncelle</button>
        </form>
      </div>
    </div>
  );
}