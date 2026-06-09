import React, { useState } from 'react';
import { Link, useNavigate, useLocation ,Outlet} from 'react-router-dom';
import AuthModal from './AuthModal'; 

export default function MemberLayout({ children }) {
  const navigate = useNavigate();
  const location = useLocation();
  const [isAuthModalOpen, setIsAuthModalOpen] = useState(false); 

  const token = localStorage.getItem('library_token');
  const isLoggedIn = !!token;

  const handleLogout = () => {
    localStorage.clear();
    navigate('/');
    window.location.reload();
  };

  const menuItems = [
  { name: 'Katalog', path: '/' },
  ...(isLoggedIn ? [
    { name: 'Ödünçlerim', path: '/my-loans' },
    { name: 'Profilim', path: '/profile' }
  ] : [])
];

  return (
    <div className="min-h-screen bg-slate-50 font-sans">
      <nav className="bg-white shadow-sm border-b border-slate-200 sticky top-0 z-50 select-none">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between h-16">
            
            <div className="flex items-center gap-8">
              <Link to="/" className="text-xl font-bold text-indigo-700 flex items-center gap-2 cursor-pointer">
                Kütüphane
              </Link>
              
              <div className="hidden md:flex space-x-1">
  {menuItems.map((item) => {
    const isActive = location.pathname === item.path;
    return (
      <Link
        key={item.path}
        to={item.path}
        className={`px-4 py-2 rounded-lg text-sm font-semibold transition-colors cursor-pointer ${
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
              {isLoggedIn ? (
                <>
                  <span className="text-sm font-medium text-slate-600 hidden sm:block">Kütüphane Üyesi</span>
                  <div className="h-9 w-9 bg-indigo-100 text-indigo-700 rounded-full flex items-center justify-center font-bold border border-indigo-200 text-sm">ÜY</div>
                  <button onClick={handleLogout} className="text-sm font-semibold text-rose-500 hover:text-rose-700 cursor-pointer ml-2 border-l pl-4 border-slate-200">
                    Çıkış Yap
                  </button>
                </>
              ) : (
                <button
                  onClick={() => setIsAuthModalOpen(true)}
                  className="px-4 py-2 bg-indigo-600 text-white rounded-lg text-sm font-semibold hover:bg-indigo-700 transition-colors cursor-pointer"
                >
                  Giriş Yap / Üye Ol
                </button>
              )}
            </div>

          </div>
        </div>
      </nav>

      <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        {children || <Outlet />}
      </main>

      <AuthModal isOpen={isAuthModalOpen} onClose={() => setIsAuthModalOpen(false)} />
    </div>
  );
}