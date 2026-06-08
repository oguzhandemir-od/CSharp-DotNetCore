import React, { useState } from 'react';
import api from '../api/axiosInstance'; 

function AddBook() {
  const [bookDto, setBookDto] = useState({
    name: '',
    publicationYear:'',
    publisher:'',
    pageCount:'',
    authorId: 0, 
    categoryId: 0
  });

  const [loading, setLoading] = useState(false);
  const [message, setMessage] = useState({ type: '', text: '' });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setBookDto({
      ...bookDto,      
      [name]: value     
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setMessage({ type: '', text: '' });

    try {
      await api.post('/Book', bookDto);

      setMessage({ type: 'success', text: '🎉 Kitap başarıyla kütüphaneye eklendi!' });
      
      setBookDto({ name: '', publicationYear:'', publisher:'', pageCount:'', authorName: '', categoryName: '' });
    } catch (error) {
      console.error(error);
      setMessage({ 
        type: 'error', 
        text: error.response?.data?.message || 'Kitap eklenirken bir hata oluştu. Yetkinizi kontrol edin!' 
      });
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ maxWidth: '500px', margin: '30px auto', padding: '20px', border: '1px solid #ddd', fontFamily: 'Arial' }}>
      <h2>🆕 Yeni Kitap Ekle</h2>
      <hr />

      {message.text && (
        <div style={{ 
          padding: '10px', 
          marginBottom: '15px', 
          backgroundColor: message.type === 'success' ? '#d4edda' : '#f8d7da',
          color: message.type === 'success' ? '#155724' : '#721c24',
          border: `1px solid ${message.type === 'success' ? '#c3e6cb' : '#f5c6cb'}`
        }}>
          {message.text}
        </div>
      )}

      <form onSubmit={handleSubmit}>
        <div style={{ marginBottom: '15px' }}>
          <label>Kitap Adı:</label>
          <input 
            type="text" 
            name="name" 
            value={bookDto.name}
            onChange={handleChange}
            style={{ width: '100%', padding: '8px', marginTop: '5px' }}
            required 
          />
        </div>

        <div style={{ marginBottom: '15px' }}>
          <label>Basım Yılı:</label>
          <input 
            type="text" 
            name="publicationYear" 
            value={bookDto.publicationYear}
            onChange={handleChange}
            style={{ width: '100%', padding: '8px', marginTop: '5px' }}
            required 
          />
        </div>

        <div style={{ marginBottom: '15px' }}>
          <label>Basım Yılı:</label>
          <input 
            type="text" 
            name="publisher" 
            value={bookDto.publisher}
            onChange={handleChange}
            style={{ width: '100%', padding: '8px', marginTop: '5px' }}
            required 
          />
        </div>

        <div style={{ marginBottom: '15px' }}>
          <label>Sayfa Sayısı:</label>
          <input 
            type="text" 
            name="pageCount" 
            value={bookDto.pageCount}
            onChange={handleChange}
            style={{ width: '100%', padding: '8px', marginTop: '5px' }}
            required 
          />
        </div>

        <div style={{ marginBottom: '15px' }}>
          <label>Yazar:</label>
          <input 
            type="text" 
            name="authorId" 
            value={bookDto.authorId}
            onChange={handleChange}
            style={{ width: '100%', padding: '8px', marginTop: '5px' }}
            required 
          />
        </div>

        <div style={{ marginBottom: '15px' }}>
          <label>Kategori:</label>
          <input 
            type="text" 
            name="categoryId" 
            value={bookDto.categoryId}
            onChange={handleChange}
            style={{ width: '100%', padding: '8px', marginTop: '5px' }}
            required 
          />
        </div>

        <button 
          type="submit" 
          disabled={loading}
          style={{ 
            width: '100%', 
            padding: '10px', 
            backgroundColor: '#28a745', 
            color: 'white', 
            border: 'none', 
            cursor: 'pointer',
            fontWeight: 'bold'
          }}
        >
          {loading ? 'Kaydediliyor...' : 'Kitabı Kaydet'}
        </button>
      </form>
    </div>
  );
}

export default AddBook;