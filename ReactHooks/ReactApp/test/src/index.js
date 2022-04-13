import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import ContactForm from './CotactForm'
import ContactFormBootstrap from './ContactFormBootstrap'
import Tick from './Tick'
import  Button  from './Button';
import Text from './Text';
import ContactFormState from './ContactFormState';
import ContacList from './ContacList'
import ContactApp from './ContactApp'




ReactDOM.render(
  <React.StrictMode>
    {/*
    <Tick/> 
    <Text firstName="Pero" lastName="Peric"/>
    <App /> 
    <ContactFormBootstrap />
    <ContactForm />
<Button/>*/}
    
    <ContactApp/>
    
    
    
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
