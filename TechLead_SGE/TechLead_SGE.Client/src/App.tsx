import { Route, BrowserRouter as Router, Routes } from 'react-router-dom';
import './App.css';
import Employees from './Components/Employees/Employees';
import Home from './Components/Home/Home';

export default function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/home" element={<Home />} />
                <Route path="/employees" element={<Employees />} />
            </Routes>
        </Router>
    );
}