
import './App.css';
import React from 'react';
import NavBar from './NavBar'
import About from './About'
import Contact from './Contact'
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'

function App() {
  return (
    <Router>
    <div >
      <NavBar/>
      <Routes>
      <Route path="/"  element={<Home/>} />      
      <Route path="/about" element={<About/>} />
      <Route path="/contact" element={<Contact/>} />
      </Routes>
    </div>
    </Router>
  );
}
const Home=()=>(
  <div>
    <h1>Home</h1>
  </div>
)

export default App;
