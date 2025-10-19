function ItemList({ items, onEdit, onDelete }) {
  if (items.length === 0) {
    return (
      <div className="items-list">
        <div className="empty-state">
          <p>No items yet. Add your first item to get started!</p>
        </div>
      </div>
    )
  }

  const formatDate = (dateString) => {
    const options = { year: 'numeric', month: 'short', day: 'numeric', hour: '2-digit', minute: '2-digit' }
    return new Date(dateString).toLocaleDateString(undefined, options)
  }

  return (
    <div className="items-list">
      {items.map((item) => (
        <div key={item.id} className="item-card">
          <div className="item-header">
            <h3 className="item-title">{item.name}</h3>
            <span className="item-category">{item.category}</span>
          </div>
          
          <p className="item-description">{item.description}</p>
          
          <div className="item-meta">
            <div>Created: {formatDate(item.createdAt)}</div>
            {item.updatedAt !== item.createdAt && (
              <div>Updated: {formatDate(item.updatedAt)}</div>
            )}
          </div>
          
          <div className="item-actions">
            <button onClick={() => onEdit(item)} className="btn-edit">
              ✏️ Edit
            </button>
            <button onClick={() => onDelete(item.id)} className="btn-delete">
              🗑️ Delete
            </button>
          </div>
        </div>
      ))}
    </div>
  )
}

export default ItemList
