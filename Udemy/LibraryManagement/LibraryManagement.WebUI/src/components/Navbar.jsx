import React from 'react';
import { Link } from 'react-router-dom'; 

function Navbar() {
  const handleLogout = () => {
    localStorage.removeItem('library_token');
    window.location.reload();
  };

  return (
    <nav style={{ backgroundColor: '#333', color: 'white', padding: '10px 20px', display: 'flex', justifyContent: 'space-between', alignItems: 'center', fontFamily: 'Arial' }}>
      <div style={{ fontWeight: 'bold', fontSize: '18px' }}>📚 Kütüphane Paneli</div>
      
      <div style={{ display: 'flex', gap: '20px' }}>
        <Link to="/" style={{ color: 'white', textDecoration: 'none' }}>Kitap Listesi</Link>
        <Link to="/add-book" style={{ color: 'white', textDecoration: 'none' }}>Yeni Kitap Ekle</Link>
      </div>

      <button onClick={handleLogout} style={{ backgroundColor: '#dc3545', color: 'white', border: 'none', padding: '6px 12px', cursor: 'pointer', borderRadius: '4px' }}>
        Çıkış Yap
      </button>
    </nav>
  );
}

export default Navbar;