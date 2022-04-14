import React from 'react';
import "./App.css"


class ContactForm extends React.Component {

  constructor() {
    super();
    this.state = {
      contacts:[],
      newContact: {
       firstName: '',
       lastName: '',
       email: '',
       message: ''
     }
     
    };
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleChange = this.handleChange.bind(this);
  }

  handleSubmit(e) {
    e.preventDefault();
    const { contacts, newContact } = this.state;
    if(newContact.firstName!='' & newContact.lastName!='' & newContact.email!='' & newContact.message!='')
    this.setState({
      contacts: [...contacts, newContact],
      newContact: {
        firstName: '',
        lastName: '',
        email: '',
        message: '',
    }});
    else alert("Molim Vas unesite sve podatke");
    
  }

  handleChange(event, element) {
    const { newContact } = this.state;
    newContact[element] = event.target.value;
    this.setState({newContact });
  }

  render() {
    const { contacts, newContact } = this.state;
    const { firstName, lastName, email, message } = newContact;
    return (   
      <div className='header'>
        
        <form onSubmit={this.handleSubmit} className='center'>
          <div>
          <input 
          type="text" 
          value={firstName} 
          onChange={event => this.handleChange(event, 'firstName')} 
          placeholder="First Name"
          required />
          </div>
          <div>
          <input 
          type="text" 
          value={lastName} 
          onChange={event => this.handleChange(event, 'lastName')} 
          placeholder="Last Name" 
          required/>
          </div>
          <div>
          <input 
          type="text" value={email} 
          onChange={event => this.handleChange(event, 'email')} 
          placeholder="Email" 
          required/>
          </div>
          <div>
          <input 
          type="text" value={message} 
          onChange={event => this.handleChange(event, 'message')} 
          placeholder="Message" 
          required/>
          </div>
          <div>
          <button type="submit" className="btn btn-primary">Submit</button>
          </div>
        </form>
        
        <div className='header'>
        {contacts.map((contact) => (
          <div key={contact.email} className='center'>
            <p>{contact.firstName}</p>
            <p>{contact.lastName}</p>
            <p>{contact.email}</p>
            <p>{contact.message}</p>
          </div>))}
        </div>
        
      </div>
    ) 
  }
}
  export default ContactForm;