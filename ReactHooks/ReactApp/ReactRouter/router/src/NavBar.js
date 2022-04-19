import React from 'react';
import'./App.css';
import{Link} from 'react-router-dom';

function NavBar()
{
    return (
        <nav>
            <ul className='navLinks'>
                <Link to="/">
                <li>Home</li>
                </Link>
                <Link to="/about">
                <li>About</li>
                </Link>
                <Link to="/contact">
                <li>Contact</li>
                </Link>
            </ul>
        </nav>
    )
}

export default NavBar;