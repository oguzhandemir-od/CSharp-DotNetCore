import React from 'react';
import { Link, useNavigate, useLocation } from 'react-router-dom';

export default function MemberLayout({ children }) {
  const navigate = useNavigate();
  const location = useLocation();

  const handleLogout = () => {
    localStorage.clear();
    navigate('/login');
    window.location.reload();
  };

  const menuItems = [
    { name: 'Katalog', path: '/catalog' },
    { name: 'Ödünçlerim', path: '/my-loans' },
    { name: 'Profilim', path: '/profile' },
  ];

  return (
    <div className="min-h-screen bg-slate-50 font-sans">
      {/* Yatay Navbar */}
      <nav className="bg-white shadow-sm border-b border-slate-200 sticky top-0 z-50 select-none">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between h-16">
            
            <div className="flex items-center gap-8">
              <span className="text-xl font-bold text-indigo-700 flex items-center gap-2">
                <svg className="w-7 h-7" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.747 0 3.332.477 4.5 1.253v13C19.832 18.477 18.247 18 16.5 18c-1.746 0-3.332.477-4.5 1.253"></path>
                </svg>
                Kütüphane Üye
              </span>
              
              <div className="hidden md:flex space-x-1">
                {menuItems.map((item) => {
                  const isActive = location.pathname === item.path;
                  return (
                    <Link
                      key={item.path}
                      to={item.path}
                      className={`px-4 py-2 rounded-lg text-sm font-semibold transition-colors ${
                        isActive
                          ? 'bg-indigo-50 text-indigo-700'
                          : 'text-slate-600 hover:text-indigo-600 hover:bg-indigo-50/50'
                      }`}
                    >
                      {item.name}
                    </Link>
                  );
                })}
              </div>
            </div>
            
            <div className="flex items-center gap-4">
              <span className="text-sm font-medium text-slate-600 hidden sm:block">Kütüphane Üyesi</span>
              <div className="h-9 w-9 bg-indigo-100 text-indigo-700 rounded-full flex items-center justify-center font-bold border border-indigo-200 text-sm">
                ÜY
              </div>
              <button
                onClick={handleLogout}
                className="text-sm font-semibold text-rose-500 hover:text-rose-700 cursor-pointer ml-2 border-l pl-4 border-slate-200"
              >
                Çıkış Yap
              </button>
            </div>

          </div>
        </div>
      </nav>

      {/* Ana İçerik Alanı */}
      <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        {children}
      </main>
    </div>
  );
}