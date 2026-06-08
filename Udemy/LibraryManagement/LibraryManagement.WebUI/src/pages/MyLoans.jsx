import React, { useState, useEffect } from 'react';
import api from '../api/axiosInstance';

export default function MyLoans() {
  const [loans, setLoans] = useState([]);
  const [loading, setLoading] = useState(true);

  const fetchMyLoans = async () => {
    try {
      setLoading(true);
      const response = await api.get('/Loan/my-loans'); 
      setLoans(response.data || []);
    } catch (err) {
      console.error("Ödünç listesi yüklenirken hata oluştu:", err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchMyLoans();
  }, []);

  const activeLoansCount = loans.filter(l => !l.isReturned && !l.IsReturned).length;

  const formatDate = (dateStr) => {
    if (!dateStr) return '-';
    return new Date(dateStr).toLocaleDateString('tr-TR');
  };

  return (
    <div className="bg-white rounded-xl shadow-sm border border-slate-200 overflow-hidden">
      <div className="px-6 py-4 border-b border-slate-100 flex justify-between items-center bg-white">
        <h3 className="text-lg font-bold text-slate-800">Ödünç Geçmişim ve Cezalarım</h3>
        <span className="text-sm font-semibold text-indigo-600 bg-indigo-50 px-3 py-1 rounded-full">
          Toplam {activeLoansCount} aktif ödünç
        </span>
      </div>

      {loading ? (
        <div className="text-center py-12 text-slate-500 font-medium">🔄 Ödünç kayıtlarınız getiriliyor...</div>
      ) : loans.length === 0 ? (
        <div className="text-center py-12 text-slate-500 font-medium">📭 Henüz hiç kitap ödünç almamışsınız.</div>
      ) : (
        <div className="overflow-x-auto">
          <table className="w-full text-left border-collapse">
            <thead className="bg-slate-50 border-b border-slate-100">
              <tr>
                <th className="px-6 py-3 text-xs font-bold text-slate-500 uppercase tracking-wider">Kitap</th>
                <th className="px-6 py-3 text-xs font-bold text-slate-500 uppercase tracking-wider">Alış Tarihi</th>
                <th className="px-6 py-3 text-xs font-bold text-slate-500 uppercase tracking-wider">Son Teslim Tarihi</th>
                <th className="px-6 py-3 text-xs font-bold text-slate-500 uppercase tracking-wider">Durum</th>
                <th className="px-6 py-3 text-xs font-bold text-slate-500 uppercase tracking-wider text-right">Ceza Tutarı</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {loans.map((loan) => {
                const isReturned = loan.isReturned ?? loan.IsReturned;
                const isDelayed = !isReturned && new Date(loan.dueDate ?? loan.DueDate) < new Date();
                
                const penaltyAmount = loan.penaltyAmount ?? loan.PenaltyAmount ?? 0;

                return (
                  <tr key={loan.id} className="hover:bg-slate-50/50 transition-colors">
                    <td className="px-6 py-4 text-sm font-semibold text-slate-900">{loan.bookName ?? loan.bookName ?? "Yükleniyor..."}</td>
                    <td className="px-6 py-4 text-sm text-slate-600">{formatDate(loan.loanDate ?? loan.LoanDate)}</td>
                    <td className="px-6 py-4 text-sm text-slate-600">{formatDate(loan.dueDate ?? loan.DueDate)}</td>
                    <td className="px-6 py-4">
                      {isReturned ? (
                        <span className="bg-emerald-50 text-emerald-700 border border-emerald-100 px-2.5 py-1 rounded-md text-xs font-bold inline-flex items-center gap-1">
                          İade Edildi
                        </span>
                      ) : isDelayed ? (
                        <span className="bg-rose-50 text-rose-700 border border-rose-100 px-2.5 py-1 rounded-md text-xs font-bold inline-flex items-center gap-1 animate-pulse">
                          ⚠️ Gecikmiş
                        </span>
                      ) : (
                        <span className="bg-amber-50 text-amber-700 border border-amber-100 px-2.5 py-1 rounded-md text-xs font-bold inline-flex items-center gap-1">
                          Sizde (Okunuyor)
                        </span>
                      )}
                    </td>
                    <td className="px-6 py-4 text-sm font-bold text-right">
                      {penaltyAmount > 0 ? (
                        <span className="text-rose-600 bg-rose-50 px-2 py-0.5 rounded border border-rose-100">₺{penaltyAmount.toFixed(2)}</span>
                      ) : (
                        <span className="text-slate-400 font-normal">-</span>
                      )}
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}