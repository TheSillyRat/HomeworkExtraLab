export default function InspectionHistory({ historyData }) {
    return (
        <div className="card">
            <div className="card-header bg-light">Inspection History</div>
            <div className="card-body p-0">
                <table className="table table-hover mb-0">
                    <thead className="table-light">
                        <tr>
                            <th>ID</th>
                            <th>Product Name</th>
                            <th>Category</th>
                            <th>Description</th>
                            <th>Status</th>
                            <th>Defect Detail</th>
                            <th>Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {historyData.length === 0 ? (
                            <tr>
                                <td colSpan="7" className="text-center text-muted py-3">No history available</td>
                            </tr>
                        ) : (
                            historyData.map(item => (
                                <tr key={item.reportId}>
                                    <td>#{item.reportId.toString().slice(-4)}</td>
                                    <td>{item.productName}</td>
                                    <td>{item.category}</td>
                                    <td>{item.inspectorName || "N/A"}</td>
                                    <td>
                                        <span className={`badge ${item.qualityStatus === 'Pass' ? 'bg-success' : 'bg-danger'}`}>
                                            {item.qualityStatus}
                                        </span>
                                    </td>
                                    <td className="text-truncate" style={{ maxWidth: '150px' }}>
                                        {item.defectDescription || "No defects"}
                                    </td>
                                    <td>{new Date(item.createAt).toLocaleDateString()}</td>
                                </tr>
                            ))
                        )}
                    </tbody>
                </table>
            </div>
        </div>
    );
}