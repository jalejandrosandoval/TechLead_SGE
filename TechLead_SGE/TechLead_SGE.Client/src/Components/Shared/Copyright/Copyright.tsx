import './Copyright.css';

// COMPONENTE DE COPYRIGHT
const Copyright = () => {
    const currentYear = new Date().getFullYear();

    return (
        <div className= "copyright">
            &copy; {currentYear} - Jhon Alejandro Sandoval Miranda. Todos los derechos Reservados...
        </div>
    );
};

// Este componente muestra el símbolo de copyright seguido del año actual y el nombre del autor.
// El año se obtiene utilizando el objeto Date de JavaScript, que devuelve la fecha y hora actuales.
export default Copyright;