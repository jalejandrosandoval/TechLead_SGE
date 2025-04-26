// DEPENDENCIES
import { faHouse } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link } from 'react-router-dom';
import './Navbar.css';

// COMPONENTE NAVEGACIÓN
// Este componente representa la barra de navegación de la aplicación. Contiene un logotipo y enlaces a diferentes secciones de la aplicación, como "Inicio" y "Empleados".
// El logotipo se muestra como una imagen y los enlaces se representan como una lista desordenada.
const Navbar = () => {
    return (
        <nav className="navbar">
            <div className="navbar-icon">
                <img src="./assets/logos/Logo_Q10.png" alt="Q10" />
            </div>
            <div className="navbar-content">
                <ul className="navbar-links">
                    <li>
                        <Link to="/home" title="Inicio">
                            <FontAwesomeIcon icon={faHouse} className="link-icon" />
                        </Link>
                    </li>
                    <li>
                        <Link to="/employees">
                            Empleados
                        </Link>
                    </li>
                </ul>
            </div>
        </nav>
    );
};

// Este componente representa la barra de navegación de la aplicación. Contiene un logotipo y enlaces a diferentes secciones de la aplicación, como "Inicio" y "Empleados".
// El logotipo se muestra como una imagen y los enlaces se representan como una lista desordenada.
export default Navbar;