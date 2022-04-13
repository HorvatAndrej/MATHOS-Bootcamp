import Form from 'react-bootstrap/Form'
import React from 'react';
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.min.css';
import "./App.css"


class ContactFormBootstrap extends React.Component {
render()
{ 
    return( 
<Form className="header" >
  <Form.Group className="header" controlId="formBasicEmail">
    <Form.Label>Email address</Form.Label>
    <Form.Control type="email" placeholder="Enter email" />
    <Form.Text className="header">
      We'll never share your email with anyone else.
    </Form.Text>
  </Form.Group>

  <Form.Group className="header" controlId="formBasicPassword">
    <Form.Label>Password</Form.Label>
    <Form.Control type="header" placeholder="Password" />
  </Form.Group>
  <Form.Group className="header" controlId="formBasicCheckbox">
    <Form.Check type="header" label="I am not a robot" />
  </Form.Group>
  <Button variant="primary" type="submit">
    Submit
  </Button>
</Form>
    );
}
}

export default ContactFormBootstrap;