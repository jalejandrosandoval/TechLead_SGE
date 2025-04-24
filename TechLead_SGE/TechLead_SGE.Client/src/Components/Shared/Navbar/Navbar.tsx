import { faHouse } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Link } from 'react-router-dom';
import './Navbar.css';

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

export default Navbar;