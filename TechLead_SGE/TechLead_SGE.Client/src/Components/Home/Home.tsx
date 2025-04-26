// DEPENDENCIES
import LayoutDefault from "../../Layouts/LayoutDefault";
import "./Home.css";

// COMPONENTE HOME
const Home = () => {
    return (
        <LayoutDefault>
            <div className="ContainerHome">
                <div className="TitleCenterHome">
                    <h2>Home...</h2>
                </div>
            </div>
        </LayoutDefault>
    );
};

// Este componente es la página de inicio de la aplicación. Utiliza el LayoutDefault para mostrar el contenido dentro de un diseño predeterminado.
// Dentro del componente, se define un contenedor con una clase CSS "ContainerHome" que contiene un título centrado "Home...".
export default Home;