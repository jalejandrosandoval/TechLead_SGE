import Copyright from "../Components/Shared/Copyright/Copyright";
import Navbar from "../Components/Shared/Navbar/Navbar";
import "./LayoutDefault.css";

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

export default LayoutDefault;