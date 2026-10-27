import { useState } from 'react';
import axios from 'axios';
import UploadFile from './UploadFile';
import PreviewForm from './PreviewForm';
import InspectionHistory from './InspectionHistory';

export default function Home() {
    const [file, setFile] = useState(null);
    const [previewData, setPreviewData] = useState(null);
    const [isLoading, setIsLoading] = useState(false);

    const [inspectionHistory, setInspectionHistory] = useState([]);

    const handleFileChange = (e) => {
        if (e.target.files && e.target.files.length > 0) {
            setFile(e.target.files[0]);
        }
        setPreviewData(null);
    };

    const handleAnalyze = async (e) => {
        e.preventDefault();
        if (!file) return;

        setIsLoading(true);
        const formData = new FormData();
        formData.append("file", file);

        try {
            const response = await axios.post("http://localhost:5021/analyze", formData);
            setPreviewData(response.data);
        } catch (error) {
            alert("Error analyzing image!");
        } finally {
            setIsLoading(false);
        }
    };

    const handleConfirm = async () => {
        try {
            const payload = {
                ...previewData,
                inspectorId: 1,
                isUserConfirmed: true
            };
           
            await axios.post("http://localhost:5021/confirm", payload);
            alert("Inspection confirmed and saved successfully!");

            setInspectionHistory([...inspectionHistory, {
                id: Date.now(),
                status: previewData.qualityStatus,
                date: new Date().toLocaleDateString()
            }]);

            setPreviewData(null);
            setFile(null);
            document.getElementById("fileInput").value = "";
        } catch (error) {
            alert("Error saving data!");
        }
    };

    const handleCancel = () => {
        setPreviewData(null);
        setFile(null);
        document.getElementById("fileInput").value = "";
    };

    return (
        <div className="container-fluid mt-4">
            <h3 className="mb-4">QC Dashboard</h3>

            <div className="row">
                <div className="col-md-5">
                    <UploadFile
                        onFileSelect={handleFileChange}
                        onAnalyze={handleAnalyze}
                        hasFile={!!file}
                        isLoading={isLoading}
                    />
                    
                    <PreviewForm
                        data={previewData}
                        file={file}
                        onConfirm={handleConfirm}
                        onCancel={handleCancel}
                    />
                </div>

                <div className="col-md-7">
                    <div className="card">
                        <div className="card-header bg-light fw-bold">Inspections history</div>
                        <div className="card-body p-0">
                            <table className="table table-hover mb-0">
                                <thead className="table-light">
                                    <tr>
                                        <th>ID</th>
                                        <th>Status</th>
                                        <th>Description</th>
                                        <th>Date</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {inspectionHistory.length === 0 ? (
                                        <tr>
                                            <td colSpan="6" className="text-center text-muted py-3">No data available</td>
                                        </tr>
                                    ) : (
                                        inspectionHistory.map(item => (
                                            <tr key={item.reportId || item.id}>
                                                <td>#{(item.reportId || item.id)?.toString().slice(-4)}</td>
                                                <td>
                                                    <span className={`badge ${(item.qualityStatus || item.status) === 'Pass' ? 'bg-success' : 'bg-danger'}`}>
                                                        {item.qualityStatus || item.status}
                                                    </span>
                                                </td>
                                                <td className="text-truncate" style={{ maxWidth: '150px' }}>
                                                    {item.defectDescription || "No description"}
                                                </td>
                                                <td>{item.createAt ? new Date(item.createAt).toLocaleDateString() : item.date}</td>
                                            </tr>
                                        ))
                                    )}
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}