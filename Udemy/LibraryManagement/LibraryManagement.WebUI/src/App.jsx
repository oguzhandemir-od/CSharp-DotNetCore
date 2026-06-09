import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import Login from './pages/Login';
import BookList from './pages/BookList';
import AddBook from './pages/AddBook'; 
import StaffLayout from './components/StaffLayout';
import MemberLayout from './components/MemberLayout';
import Catalog from './pages/Catalog';
import MyLoans from './pages/MyLoans';
import Profile from './pages/Profile';
import Authors from './pages/Authors';
import Categories from './pages/Categories';
import LendingTransactions from './pages/LendingTransactions';
import Members from './pages/Members';
import Staff from './pages/Staff'
import Dashboard from './pages/Dashboard';

function App() {
  const token = localStorage.getItem('library_token');
  const role = localStorage.getItem('user_role'); 

  console.log("--- ROTA KONTROLÜ ---");
  console.log("Mevcut Adres:", window.location.pathname);
  console.log("Token Var mı?:", !!token);
  console.log("Okunan Rol:", role);

 /*  if (!token) {
    return (
      <Router>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="*" element={<Navigate to="/login" />} />
        </Routes>
      </Router>
    );
  } */

  /* if (role === 'staff') {
    return (
      <Router>
        <StaffLayout>
          <Routes>
            <Route path="/" element={<BookList />} />
            <Route path="/add-book" element={<AddBook />} />
            
            <Route path="/authors" element={<Authors />} />
            <Route path="/categories" element={<Categories/>} />
            <Route path="/loans" element={<LendingTransactions/>} />
            <Route path="/members" element={< Members/>}/>
            <Route path='/staff' element={< Staff/>} />
            
            <Route path="*" element={<Navigate to="/" />} />
          </Routes>
        </StaffLayout>
      </Router>
    );
  }

  if (role === 'member') {
    return (
      <Router>
        <MemberLayout>
          <Routes>
            <Route path="/catalog" element={<Catalog />} />
            <Route path="/my-loans" element={<MyLoans />} />
            <Route path="/profile" element={<Profile />} />
            
            <Route path="*" element={<Navigate to="/catalog" />} />
          </Routes>
        </MemberLayout>
          
      </Router>
    );
  } */

    return (
    <Router>
      <Routes>
        {/* PERSONEL GİRİŞİ (GİZLİ) */}
        <Route path="/staff-login" element={!token ? <Login /> : <Navigate to="/" />} />

        {/* 🌍 HERKESE AÇIK ANA SAYFA (KATALOG) */}
        <Route path="/" element={
          role === 'staff' ? (
            <StaffLayout><Dashboard /></StaffLayout>
          ) : (
            <MemberLayout><Catalog /></MemberLayout>
          )
        } />

        {/* SADECE ÜYELER */}
        {token && role === 'member' && (
          <>
            <Route path="/my-loans" element={<MemberLayout><MyLoans /></MemberLayout>} />
            <Route path="/profile" element={<MemberLayout><Profile /></MemberLayout>} />
          </>
        )}

        {/* SADECE PERSONEL */}
        {token && role === 'staff' && (
          <>
            <Route path="/books" element={<StaffLayout><BookList /></StaffLayout>} />
            <Route path="/authors" element={<StaffLayout><Authors /></StaffLayout>} />
            <Route path="/categories" element={<StaffLayout><Categories /></StaffLayout>} />
            <Route path="/loans" element={<StaffLayout><LendingTransactions /></StaffLayout>} />
            <Route path="/members" element={<StaffLayout><Members /></StaffLayout>} />
            <Route path="/staff" element={<StaffLayout><Staff /></StaffLayout>} />
          </>
        )}

        {/* JOKER */}
        <Route path="*" element={<Navigate to="/" />} />
      </Routes>
    </Router>
  );
}

export default App;