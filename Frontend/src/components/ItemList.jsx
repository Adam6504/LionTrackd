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
        <div key={item.id || item.Id} className="item-card">
          <div className="item-header">
            <h3 className="item-title">{item.name || item.Name}</h3>
            <span className="item-category">{item.category || item.Category}</span>
          </div>
          
          <p className="item-description">{item.description || item.Description}</p>
          
          {(item.reward || item.Reward) > 0 && (
            <div className="item-reward">
              Reward: ${(item.reward || item.Reward).toFixed(2)}
            </div>
          )}
          
          <div className="item-meta">
            <div>Created: {formatDate(item.createdAt || item.CreatedAt)}</div>
            {(item.updatedAt || item.UpdatedAt) !== (item.createdAt || item.CreatedAt) && (
              <div>Updated: {formatDate(item.updatedAt || item.UpdatedAt)}</div>
            )}
          </div>
          
          <div className="item-actions">
            <button onClick={() => onEdit(item)} className="btn-edit">
              Edit
            </button>
            <button onClick={() => onDelete(item.id || item.Id)} className="btn-delete">
              Delete
            </button>
          </div>
        </div>
      ))}
    </div>
  )
}

export default ItemList
