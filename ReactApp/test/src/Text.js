import React from 'react'
import "./App.css"


class Text extends React.Component {
    render() {
      return(
        <div className="header">
        <table>
	          <tr>
		          <td>First Name</td>
		          <td>Last Name</td>				
	          </tr>
	          <tr>
		          <td>{this.props.firstName}</td>
		          <td>{this.props.lastName}</td>
            </tr>
        </table>
        </div>
      )

    }
  }
export default Text;

