import React from 'react';
import {useState} from 'react';

export default function ContactList({contacts}) {
    return (
      <div className='header'>
        {contacts.map((contact) => (
          <div key={contact.Email}>
            <p>{contact.FirstName}</p>
            <p>{contact.LastName}</p>
            <p>{contact.Email}</p>
            <p>{contact.Message}</p>
          </div>
        ))}
      </div>
    );
        }

