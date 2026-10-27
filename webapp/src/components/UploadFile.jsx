export default function UploadForm({ onFileSelect, onAnalyze, hasFile, isLoading }) {
    return (
        <div className="card mb-3">
            <div className="card-body">
                <form onSubmit={onAnalyze}>
                    <label className="form-label fw-bold">Upload Product Image</label>
                    <input
                        type="file"
                        id="fileInput"
                        className="form-control mb-3"
                        accept="image/*"
                        onChange={onFileSelect}
                        required
                    />
                    <button
                        type="submit"
                        className="btn btn-primary w-100"
                        disabled={!hasFile || isLoading}
                    >
                        {isLoading ? "Processing..." : "Analyze Image"}
                    </button>
                </form>
            </div>
        </div>
    );
}