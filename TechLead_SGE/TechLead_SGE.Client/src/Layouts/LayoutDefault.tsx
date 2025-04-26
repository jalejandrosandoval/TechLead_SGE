// Dependencias
import React from "react";
import Copyright from "../Components/Shared/Copyright/Copyright";
import Navbar from "../Components/Shared/Navbar/Navbar";
import "./LayoutDefault.css";

// COMPONENTE DE LAYOUT POR DEFECTO
// Este componente representa el diseño por defecto de la aplicación. Contiene una barra de navegación, un fondo y un contenedor para el contenido principal.  
const LayoutDefault: React.FC<{ children?: React.ReactNode }> = ({ children }) => {
    return (
        <div className="init-container">
            <Navbar />
            <div className="background-image"></div>
            <div className="content-container">
                {children}
            </div>
            <Copyright />
        </div>
    )
}

// Este componente utiliza el componente Navbar para mostrar la barra de navegación y el componente Copyright para mostrar el aviso de copyright al final de la página.
// El contenedor principal tiene una clase CSS "init-container" que se utiliza para aplicar estilos y un fondo a la página.
export default LayoutDefault;