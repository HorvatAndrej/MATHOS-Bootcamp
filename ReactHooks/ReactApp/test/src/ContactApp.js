import { useState } from "react";
import ContactList from "./ContacList";
import ContactFormState from "./ContactFormState";



function ContactApp() {

  const [contacts, updateContacts] = useState([]);

  const addContact = (contact) => {
    updateContacts([...contacts, contact]);
  };

  return (
    <div>
      <ContactFormState addContact={addContact} />
      <ContactList contacts={contacts} />
    </div>
  );
}

export default ContactApp;