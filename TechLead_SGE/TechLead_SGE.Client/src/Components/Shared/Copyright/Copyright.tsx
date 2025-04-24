import './Copyright.css';

const Copyright = () => {
    const currentYear = new Date().getFullYear();

    return (
        <div className= "copyright">
            &copy; {currentYear} - Jhon Alejandro Sandoval Miranda. Todos los derechos Reservados...
        </div>
    );
};

export default Copyright;