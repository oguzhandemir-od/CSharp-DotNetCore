import React, { useState, useEffect } from 'react';
import api from '../api/axiosInstance';

export default function Dashboard() {
  const [stats, setStats] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  const fetchDashboardStats = async () => {
    try {
      setLoading(true);
      const response = await api.get('/Stats/dashboard'); 
      setStats(response.data);
    } catch (err) {
      console.error("Dashboard istatistikleri yüklenemedi:", err);
      setError("Veriler yüklenirken bir hata oluştu. Lütfen backend endpoint'inizi kontrol edin.");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchDashboardStats();
  }, []);

  if (loading) {
    return (
      <div className="flex flex-col items-center justify-center py-24 space-y-3">
        <div className="text-xl font-medium text-slate-600 animate-pulse">📊 İstatistikler Hesaplanıyor...</div>
        <p className="text-xs text-slate-400">Veritabanı özetleri ve canlı veriler analiz ediliyor.</p>
      </div>
    );
  }

  if (error) {
    return (
      <div className="p-6 bg-rose-50 border border-rose-100 rounded-2xl text-rose-600 text-sm max-w-2xl mx-auto text-center font-medium mt-12">
        ⚠️ {error}
      </div>
    );
  }

  return (
    <div className="space-y-8 select-none animate-in fade-in duration-300">
      
      {/* Üst Karşılama Alanı */}
      <div>
        <h1 className="text-2xl font-bold text-slate-800">Yönetim Paneli</h1>
        <p className="text-slate-500 text-xs mt-1">Kütüphane anlık durumu, bekleyen işlemler ve finansal özet.</p>
      </div>

      {/* 📊 SAYAÇ KARTLARI (GRID) */}
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6">
        
        {/* Kart 1: Toplam Kitap */}
        <div className="bg-white p-6 rounded-2xl border border-slate-200/80 shadow-xs flex items-center justify-between">
          <div>
            <span className="text-xs font-semibold text-slate-400 block mb-1">Toplam Kitap</span>
            <span className="text-3xl font-bold text-slate-800">{stats?.totalBooks ?? 0}</span>
          </div>
          <div className="h-12 w-12 bg-indigo-50 text-indigo-600 rounded-xl flex items-center justify-center">
            <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.747 0 3.332.477 4.5 1.253v13C19.832 18.477 18.247 18 16.5 18c-1.746 0-3.332.477-4.5 1.253"></path></svg>
          </div>
        </div>

        {/* Kart 2: Kayıtlı Üye */}
        <div className="bg-white p-6 rounded-2xl border border-slate-200/80 shadow-xs flex items-center justify-between">
          <div>
            <span className="text-xs font-semibold text-slate-400 block mb-1">Kayıtlı Üye</span>
            <span className="text-3xl font-bold text-slate-800">{stats?.totalMembers ?? 0}</span>
          </div>
          <div className="h-12 w-12 bg-emerald-50 text-emerald-600 rounded-xl flex items-center justify-center">
            <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z"></path></svg>
          </div>
        </div>

        {/* Kart 3: Ödünçteki Kitaplar */}
        <div className="bg-white p-6 rounded-2xl border border-slate-200/80 shadow-xs flex items-center justify-between">
          <div>
            <span className="text-xs font-semibold text-slate-400 block mb-1">Ödünçteki Kitaplar</span>
            <span className="text-3xl font-bold text-slate-800">{stats?.activeLoans ?? 0}</span>
          </div>
          <div className="h-12 w-12 bg-amber-50 text-amber-600 rounded-xl flex items-center justify-center">
            <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z"></path></svg>
          </div>
        </div>

        {/* Kart 4: Bekleyen Cezalar */}
        <div className="bg-white p-6 rounded-2xl border border-slate-200/80 shadow-xs flex items-center justify-between">
          <div>
            <span className="text-xs font-semibold text-slate-400 block mb-1">Bekleyen Cezalar</span>
            <span className="text-3xl font-bold text-rose-600">₺{stats?.totalUnpaidPenalties ?? 0}</span>
          </div>
          <div className="h-12 w-12 bg-rose-50 text-rose-600 rounded-xl flex items-center justify-center">
            <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path></svg>
          </div>
        </div>

      </div>

      {/* 🕒 TABLOLAR ALANI (İKİLİ GRID) */}
      <div className="grid grid-cols-1 lg:grid-cols-2 gap-8">
        
        {/* Tablo 1: Son Ödünç İşlemleri */}
        <div className="bg-white rounded-2xl border border-slate-200 shadow-xs overflow-hidden">
          <div className="px-6 py-4 border-b border-slate-100 flex justify-between items-center bg-slate-50/50">
            <h3 className="text-sm font-bold text-slate-700 flex items-center gap-2">
              <span className="w-2 h-2 bg-indigo-500 rounded-full"></span> Son Ödünç Verilenler
            </h3>
            <span className="text-[10px] bg-indigo-50 text-indigo-600 px-2 py-0.5 rounded-md font-bold">Canlı Veri</span>
          </div>
          
          <div className="overflow-x-auto">
            <table className="w-full text-left border-collapse">
              <thead>
                <tr className="bg-slate-50 text-slate-400 text-[10px] font-bold uppercase border-b border-slate-100">
                  <th className="px-6 py-3">Kitap</th>
                  <th className="px-6 py-3">Teslim Alan Üye</th>
                  <th className="px-6 py-3">İşlem Tarihi</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100 text-xs">
                {stats?.recentLoans?.length === 0 ? (
                  <tr>
                    <td colSpan="3" className="text-center py-8 text-slate-400">Henüz bir işlem kaydı yok.</td>
                  </tr>
                ) : (
                  stats?.recentLoans?.map((loan) => (
                    <tr key={loan.loanId} className="hover:bg-slate-50/50 transition-colors">
                      <td className="px-6 py-3.5 font-bold text-slate-800 uppercase line-clamp-1 max-w-[180px]">{loan.bookName}</td>
                      <td className="px-6 py-3.5 text-slate-600 font-medium">{loan.memberFullName}</td>
                      <td className="px-6 py-3.5 text-slate-500">{new Date(loan.loanDate).toLocaleDateString('tr-TR')}</td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>
        </div>

        {/* Tablo 2: Süresi Geciken Kitaplar */}
        <div className="bg-white rounded-2xl border border-slate-200 shadow-xs overflow-hidden">
          <div className="px-6 py-4 border-b border-slate-100 flex justify-between items-center bg-slate-50/50">
            <h3 className="text-sm font-bold text-slate-700 flex items-center gap-2">
              <span className="w-2 h-2 bg-rose-500 rounded-full"></span> Süresi Gecikenler (Kritik)
            </h3>
            <span className="text-[10px] bg-rose-50 text-rose-600 px-2 py-0.5 rounded-md font-bold">Takip Gerekli</span>
          </div>

          <div className="overflow-x-auto">
            <table className="w-full text-left border-collapse">
              <thead>
                <tr className="bg-slate-50 text-slate-400 text-[10px] font-bold uppercase border-b border-slate-100">
                  <th className="px-6 py-3">Kitap</th>
                  <th className="px-6 py-3">Üye</th>
                  <th className="px-6 py-3 text-right">Gecikme Süresi</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100 text-xs">
                {stats?.overdueLoans?.length === 0 ? (
                  <tr>
                    <td colSpan="3" className="text-center py-8 text-emerald-600 font-medium bg-emerald-50/10">🎉 Harika! Süresi geciken kitap bulunmuyor.</td>
                  </tr>
                ) : (
                  stats?.overdueLoans?.map((loan) => (
                    <tr key={loan.loanId} className="hover:bg-rose-50/5 transition-colors">
                      <td className="px-6 py-3.5 font-bold text-slate-800 uppercase line-clamp-1 max-w-[180px]">{loan.bookName}</td>
                      <td className="px-6 py-3.5 text-slate-600 font-medium">{loan.memberFullName}</td>
                      <td className="px-6 py-3.5 text-right font-bold text-rose-600 animate-pulse">
                        {loan.delayDays} Gün Gecikti
                      </td>
                    </tr>
                  ))
                )}
              </tbody>
            </table>
          </div>
        </div>

      </div>

    </div>
  );
}