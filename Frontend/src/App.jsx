import { useState, useEffect } from 'react'
import './App.css'
import ItemList from './components/ItemList'
import ItemForm from './components/ItemForm'
import { getItems, createItem, updateItem, deleteItem } from './services/api'

function App() {
  const [items, setItems] = useState([])
  const [editingItem, setEditingItem] = useState(null)
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState(null)

  // Fetch all items on component mount
  useEffect(() => {
    fetchItems()
  }, [])

  const fetchItems = async () => {
    try {
      setLoading(true)
      const data = await getItems()
      setItems(data)
      setError(null)
    } catch (err) {
      setError('Failed to fetch items. Make sure the backend is running.')
      console.error('Error fetching items:', err)
    } finally {
      setLoading(false)
    }
  }

  const handleCreateItem = async (itemData) => {
    try {
      await createItem(itemData)
      await fetchItems()
    } catch (err) {
      setError('Failed to create item')
      console.error('Error creating item:', err)
    }
  }

  const handleUpdateItem = async (id, itemData) => {
    try {
      await updateItem(id, itemData)
      await fetchItems()
      setEditingItem(null)
    } catch (err) {
      setError('Failed to update item')
      console.error('Error updating item:', err)
    }
  }

  const handleDeleteItem = async (id) => {
    try {
      await deleteItem(id)
      await fetchItems()
    } catch (err) {
      setError('Failed to delete item')
      console.error('Error deleting item:', err)
    }
  }

  const handleEdit = (item) => {
    setEditingItem(item)
  }

  const handleCancelEdit = () => {
    setEditingItem(null)
  }

  return (
    <div className="App">
      <header className="App-header">
        <h1>LionTrackd</h1>
        <p>Full-Stack .NET + React + MongoDB Application</p>
      </header>

      <main className="App-main">
        {error && (
          <div className="error-message">
            {error}
            <button onClick={() => setError(null)}>✕</button>
          </div>
        )}

        <div className="container">
          <section className="form-section">
            <h2>{editingItem ? 'Edit Item' : 'Add New Item'}</h2>
            <ItemForm
              item={editingItem}
              onSubmit={editingItem ? handleUpdateItem : handleCreateItem}
              onCancel={editingItem ? handleCancelEdit : null}
            />
          </section>

          <section className="list-section">
            <h2>Items</h2>
            {loading ? (
              <p>Loading items...</p>
            ) : (
              <ItemList
                items={items}
                onEdit={handleEdit}
                onDelete={handleDeleteItem}
              />
            )}
          </section>
        </div>
      </main>
    </div>
  )
}

export default App
