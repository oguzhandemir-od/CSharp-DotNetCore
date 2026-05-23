using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList;
using static ToDoList.Kart;

namespace ToDoUygulama
{
    internal class Line
    {
        private List<Kart> _todoline;
        private List<Kart> _inprogressline;
        private List<Kart> _doneline;
        private static Line _line;

        public List<Kart> Todoline { get => _todoline; set => _todoline = value; }
        public List<Kart> Inprogressline { get => _inprogressline; set => _inprogressline = value; }
        public List<Kart> Doneline { get => _doneline; set => _doneline = value; }
        public static Line Basla()
        {
            if (_line == null)
                _line = new Line();
            return _line;
        }
        private Line()
        {
            Todoline = new List<Kart>();
            Inprogressline = new List<Kart>();
            Doneline = new List<Kart>();

            Kart kart1 = new Kart { Baslik = "Kart 1", Icerik = "Kart 1 İçeriği", Buyukluk = Boyut.XS.ToString(), AtananKisiID = 110, Linetipi = 1 };
            Kart kart2 = new Kart { Baslik = "Kart 2", Icerik = "Kart 2 İçeriği", Buyukluk = Boyut.L.ToString(), AtananKisiID = 130, Linetipi = 2 };
            Kart kart3 = new Kart { Baslik = "Kart 3", Icerik = "Kart 3 İçeriği", Buyukluk = Boyut.M.ToString(), AtananKisiID = 150, Linetipi = 3 };

            Todoline.Add(kart1);
            Inprogressline.Add(kart2);
            Doneline.Add(kart3);
        }

    }
}
