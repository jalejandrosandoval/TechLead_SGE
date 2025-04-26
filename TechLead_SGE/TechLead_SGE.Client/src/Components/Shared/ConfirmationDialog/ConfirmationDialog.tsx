import React from "react";
import "./ConfirmationDialog.css";

interface ConfirmationDialogProps {
    visible: boolean;
    message: string;
    onConfirm: () => void;
    onCancel: () => void;
}

const ConfirmationDialog: React.FC<ConfirmationDialogProps> = ({ visible, message, onConfirm, onCancel }) => {
    if (!visible) return null;

    return (
        <div className="confirmation-dialog-overlay">
            <div className="confirmation-dialog">
                <p>{message}</p>
                <div className="confirmation-dialog-actions">
                    <button className="cancel-button" onClick={onCancel}>
                        Cancelar
                    </button>
                    <button className="confirm-button" onClick={onConfirm}>
                        Confirmar
                    </button>
                </div>
            </div>
        </div>
    );
};

export default ConfirmationDialog;