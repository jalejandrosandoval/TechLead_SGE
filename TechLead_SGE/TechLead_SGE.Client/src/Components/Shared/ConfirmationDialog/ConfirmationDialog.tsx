import React from "react";
import "./ConfirmationDialog.css";

// COMPONENTE DE CONFIRMACIÓN
// Este componente se utiliza para mostrar un cuadro de diálogo de confirmación al usuario.
interface ConfirmationDialogProps {
    visible: boolean;
    message: string;
    onConfirm: () => void;
    onCancel: () => void;
}

// Este componente recibe las siguientes propiedades: 
// - visible: un booleano que indica si el cuadro de diálogo debe mostrarse o no.
// - message: un string que contiene el mensaje que se mostrará en el cuadro de diálogo.
// - onConfirm: una función que se ejecutará cuando el usuario haga clic en el botón de confirmación.
// - onCancel: una función que se ejecutará cuando el usuario haga clic en el botón de cancelación.
// El componente devuelve un cuadro de diálogo que contiene el mensaje y dos botones: "Cancelar" y "Confirmar".
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