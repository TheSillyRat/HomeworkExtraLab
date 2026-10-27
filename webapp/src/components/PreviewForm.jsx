export default function PreviewForm({ data, onConfirm, file, onCancel }) {
    if (!data) return null;
    const imageSrc = file ? URL.createObjectURL(file) : `http://localhost:5021${data.imageUrl}`;

    return (
        <div className="card border-primary">
            <div className="card-header bg-primary text-white fw-bold">Inspection Preview</div>
            <div className="card-body">
                <img
                    src={file ? URL.createObjectURL(file) : (data.imageUrl ? `http://localhost:5021${data.imageUrl}` : "/placeholder.png")}
                    alt="Preview"
                    className="img-fluid mb-3 border"
                />
                <p className="mb-1"><strong>Product:</strong> {data.productName || "N/A"}</p>
                <p className="mb-1"><strong>Category:</strong> {data.category || "N/A"}</p>
                <p className="mb-1"><strong>Status:</strong> {data.qualityStatus}</p>
                <p className="mb-1"><strong>Confidence:</strong> {(data.confidenceScore * 100).toFixed(1)}%</p>
                <p className="mb-3">
                    <strong>Detail:</strong> {data.defectDescription || "No defects detected"}
                </p>

                <div className="d-flex gap-2">
                    <button className="btn btn-outline-danger w-50 fw-bold" onClick={onCancel}>
                        Reject
                    </button>
                    <button className="btn btn-success w-50 fw-bold" onClick={onConfirm}>
                        Confirm & Save
                    </button>
                </div>
            </div>
        </div>
    );
}