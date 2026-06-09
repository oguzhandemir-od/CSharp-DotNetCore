using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Application.DTOs
{
    public class DashboardStatsDto
    {
        // Üst Sayaç Kartları
        public int TotalBooks { get; set; }
        public int TotalMembers { get; set; }
        public int ActiveLoans { get; set; } // Teslim edilmemiş (IsReturned == false) olanlar
        public decimal TotalUnpaidPenalties { get; set; } // Ödenmemiş cezaların toplam tutarı

        // Listeler ve Özetler
        public List<RecentLoanDto> RecentLoans { get; set; } // Son ödünç verilen 5 kitap
        public List<OverdueLoanDto> OverdueLoans { get; set; } // Geciken ve teslim edilmeyen kitaplar
    }

    public class RecentLoanDto
    {
        public int LoanId { get; set; }
        public string BookName { get; set; }
        public string MemberFullName { get; set; }
        public DateTime LoanDate { get; set; }
        public string StaffFullName { get; set; }
    }

    public class OverdueLoanDto
    {
        public int LoanId { get; set; }
        public string BookName { get; set; }
        public string MemberFullName { get; set; }
        public DateTime DueDate { get; set; }
        public int DelayDays { get; set; } // Kaç gün geciktiği (DateTime.UtcNow - DueDate)
    }
}
