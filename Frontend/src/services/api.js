import axios from 'axios'

const API_URL = 'http://localhost:5237/api'

const api = axios.create({
  baseURL: API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
})

// Get all items
export const getItems = async () => {
  const response = await api.get('/items')
  return response.data
}

// Get single item by ID
export const getItem = async (id) => {
  const response = await api.get(`/items/${id}`)
  return response.data
}

// Create new item
export const createItem = async (itemData) => {
  const response = await api.post('/items', itemData)
  return response.data
}

// Update existing item
export const updateItem = async (id, itemData) => {
  const response = await api.put(`/items/${id}`, itemData)
  return response.data
}

// Delete item
export const deleteItem = async (id) => {
  const response = await api.delete(`/items/${id}`)
  return response.data
}

export default api
