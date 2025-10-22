import { useState, useEffect } from 'react'

function ItemForm({ item, onSubmit, onCancel }) {
  const [formData, setFormData] = useState({
    name: '',
    description: '',
    category: '',
    reward: 0,
  })

  useEffect(() => {
    if (item) {
      setFormData({
        name: item.name || '',
        description: item.description || '',
        category: item.category || '',
        reward: item.reward || 0,
      })
    } else {
      setFormData({
        name: '',
        description: '',
        category: '',
        reward: 0,
      })
    }
  }, [item])

  const handleChange = (e) => {
    const { name, value } = e.target
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }))
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    if (item) {
      const itemId = item.id || item.Id
      onSubmit(itemId, formData)
    } else {
      onSubmit(formData)
    }
    setFormData({ name: '', description: '', category: '', reward: 0 })
  }

  return (
    <form onSubmit={handleSubmit} className="item-form">
      <div className="form-group">
        <label htmlFor="name">Name *</label>
        <input
          type="text"
          id="name"
          name="name"
          value={formData.name}
          onChange={handleChange}
          required
          placeholder="Enter item name"
        />
      </div>

      <div className="form-group">
        <label htmlFor="description">Description *</label>
        <textarea
          id="description"
          name="description"
          value={formData.description}
          onChange={handleChange}
          required
          placeholder="Enter item description"
        />
      </div>

      <div className="form-group">
        <label htmlFor="category">Category *</label>
        <input
          type="text"
          id="category"
          name="category"
          value={formData.category}
          onChange={handleChange}
          required
          placeholder="Enter category"
        />
      </div>

      <div className="form-group">
        <label htmlFor="reward">Reward ($)</label>
        <input
          type="number"
          id="reward"
          name="reward"
          value={formData.reward}
          onChange={handleChange}
          min="0"
          step="0.01"
          placeholder="Enter reward amount (optional)"
        />
      </div>

      <div className="form-actions">
        <button type="submit" className="btn-primary">
          {item ? 'Update Item' : 'Add Item'}
        </button>
        {onCancel && (
          <button type="button" onClick={onCancel} className="btn-secondary">
            Cancel
          </button>
        )}
      </div>
    </form>
  )
}

export default ItemForm
