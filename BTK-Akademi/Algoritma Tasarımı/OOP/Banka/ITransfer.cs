using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Banka
{
    public interface ITransfer: IBankaHesap
    {
        bool TransferYap(IBankaHesap aliciHesap, decimal miktar);
    }
}
