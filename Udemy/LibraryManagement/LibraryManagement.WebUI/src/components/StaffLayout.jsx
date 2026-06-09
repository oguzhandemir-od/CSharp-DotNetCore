import React from "react";
import { Link, useNavigate, useLocation } from "react-router-dom";
import { Outlet } from 'react-router-dom';

export default function StaffLayout({ children }) {
  const navigate = useNavigate();
  const location = useLocation(); 

  const handleLogout = () => {
    localStorage.removeItem("library_token");
    localStorage.removeItem("user_role");
    navigate("/login");
    window.location.reload();
  };

  const menuItems = [
    { name: "Dashboard", path: "/" },
    { name: "Kitap Yönetimi", path: "/books" },
    { name: "Yazar Yönetimi", path: "/authors" },
    { name: "Kategori Yönetimi", path: "/categories" },
    { name: "Ödünç İşlemleri", path: "/loans" },
    { name: "Üye İşlemleri", path: "/members" },
    { name: "Personel İşlemleri", path: "/staff" }
  ];

  const currentMenu = menuItems.find((item) => item.path === location.pathname);
  const pageTitle = currentMenu ? currentMenu.name : "Personel Paneli";

  return (
    <div className="flex h-screen bg-slate-50 font-sans">
      {/* Sidebar */}
      <aside className="w-64 bg-slate-900 text-slate-300 flex flex-col shadow-xl select-none">
        <div className="p-6 border-b border-slate-800">
          <h1 className="text-xl font-bold text-white flex items-center gap-2">
            <svg
              className="w-6 h-6 text-indigo-400"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.747 0 3.332.477 4.5 1.253v13C19.832 18.477 18.247 18 16.5 18c-1.746 0-3.332.477-4.5 1.253"
              ></path>
            </svg>
            Kütüphane Panel
          </h1>
        </div>

        <nav className="flex-1 p-4 space-y-1">
          {menuItems.map((item) => {
            const isActive = location.pathname === item.path;
            return (
              <Link
                key={item.path}
                to={item.path}
                className={`flex items-center gap-3 px-4 py-3 rounded-lg transition-colors font-medium ${
                  isActive
                    ? "bg-indigo-600 text-white shadow-md shadow-indigo-600/10"
                    : "hover:bg-slate-800 hover:text-white text-slate-400"
                }`}
              >
                <svg
                  className="w-5 h-5"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth="2"
                    d="M4 6h16M4 12h16M4 18h16"
                  ></path>
                </svg>
                {item.name}
              </Link>
            );
          })}
        </nav>

        <div className="p-4 border-t border-slate-800">
          <button
            onClick={handleLogout}
            className="w-full flex items-center gap-3 px-4 py-3 rounded-lg text-rose-400 hover:bg-rose-500/10 hover:text-rose-300 transition-colors font-medium text-left"
          >
            <svg
              className="w-5 h-5"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1"
              ></path>
            </svg>
            Çıkış Yap
          </button>
        </div>
      </aside>

      {/* Ana İçerik Alanı */}
      <div className="flex-1 flex flex-col overflow-hidden">
        {/* Top Navbar */}
        <header className="bg-white shadow-sm border-b border-slate-200 h-16 flex items-center justify-between px-8 z-10">
          <h2 className="text-lg font-bold text-slate-800">{pageTitle}</h2>
          <div className="flex items-center gap-4">
            <span className="text-sm text-slate-600">
              Hoşgeldin,{" "}
              <span className="font-semibold text-slate-900">
                Kütüphane Görevlisi
              </span>
            </span>
            <div className="h-9 w-9 bg-indigo-100 text-indigo-700 rounded-full flex items-center justify-center font-bold border border-indigo-200 text-sm">
              KG
            </div>
          </div>
        </header>

        <main className="flex-1 overflow-y-auto p-8 bg-slate-50">
          {children || <Outlet />}
        </main>
      </div>
    </div>
  );
}
