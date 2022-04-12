import React from 'react';
import "./App.css"


class ContactForm extends React.Component {
    constructor(props) {
      super(props);
      this.state = {
        name: '',
        email: '',
        message: ''
      }
    }
  
    render() {
      return(
        <div className="header">
          <form id="contact-form" onSubmit={this.handleSubmit.bind(this)}  method="POST">
            <div className="header">
              <label htmlFor="name">Name</label>
              <input type="text" className="form-control" value={this.state.name} onChange={this.onNameChange.bind(this)} placeholder='Enter name'/>
            </div>
            <div className="header">
              <label htmlFor="exampleInputEmail1">Email address</label>
              <input type="email" className="form-control" aria-describedby="emailHelp" value={this.state.email} onChange={this.onEmailChange.bind(this)} placeholder='Enter email'/>
            </div>
            <div className="header">
              <label htmlFor="message">Message</label>
              <textarea className="form-control" rows="5" value={this.state.message} onChange={this.onMessageChange.bind(this)} placeholder='Message' />
            </div>
            <button type="submit" className="btn btn-primary">Submit</button>
          </form>
        </div>
      );
    }
  
    onNameChange(event) {
      this.setState({name: event.target.value})
    }
  
    onEmailChange(event) {
      this.setState({email: event.target.value})
    }
  
    onMessageChange(event) {
      this.setState({message: event.target.value})
    }
  
    handleSubmit(event) {
    }
  }
  
  export default ContactForm;