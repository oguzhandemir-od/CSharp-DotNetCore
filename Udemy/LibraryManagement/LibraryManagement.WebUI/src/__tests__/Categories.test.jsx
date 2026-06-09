import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import '@testing-library/jest-dom';
import { beforeEach, describe, test, expect, vi } from 'vitest';
import Categories from '../pages/Categories'; 
import api from '../api/axiosInstance'; 

vi.mock('../api/axiosInstance'); 

const mockNavigate = vi.fn();
vi.mock('react-router-dom', () => ({
  useNavigate: () => mockNavigate
}));

describe('Categories Kategori Yönetimi Testleri', () => {
  
  beforeEach(() => {
    vi.clearAllMocks();
  });

  test('Yeni kategori ekleme formu doldurulup kaydedildiğinde API post isteği atmalı', async () => {
    api.get.mockResolvedValueOnce({ data: [] });
    
    api.post.mockResolvedValueOnce({ data: { success: true } });

    render(<Categories />);

    await waitFor(() => {
      expect(document.querySelector('.animate-spin')).toBeNull();
    });

    const newCategoryButton = screen.getByRole('button', { name: /Yeni Kategori/i });
    fireEvent.click(newCategoryButton);

    expect(screen.getByText('Yeni Kategori Ekle')).toBeInTheDocument();

    const inputField = screen.getByPlaceholderText('Örn: Edebiyat');
    fireEvent.change(inputField, { target: { value: 'Roman' } });

    const saveButton = screen.getByRole('button', { name: 'Kaydet' });
    fireEvent.click(saveButton);

    await waitFor(() => {
      expect(api.post).toHaveBeenCalledWith('/Category', {
        Name: 'Roman'
      });
    });

    expect(screen.queryByText('Yeni Kategori Ekle')).not.toBeInTheDocument();

    expect(api.get).toHaveBeenCalledTimes(2); 
  });
});