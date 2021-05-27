import React from 'react';
import axios from 'axios';
/**
 * App
 *
 * Simple react js fetch example
 */
class App extends React.Component {
    constructor(props) {

        super(props);

        this.state = {
            items: [],
            isLoaded: false
        }

    }

    componentDidMount() {

        fetch('https://localhost:44319/api/Animal')
            .then(res => res.json())
            .then(json => {
                this.setState({
                    items: json,
                    isLoaded: true, 
                })
            }).catch((err) => {
                console.log(err);
            });

    }
    render() {

        const { isLoaded, items } = this.state;

        if (!isLoaded)
            return <div>Loading...</div>;

        return (
            <div className="App">
              <table>
                <tr>
                  <th>Animal name</th>
                  <th>Animal Type</th>
                </tr>
                <tr>
                  <td>
                    {items.map(item => (
                      <p key = {item.AnimalID}  style={{textAlign:"center"}}>{item.AnimalName}</p>
                    ))}  
                  </td>
                  <td>
                    {items.map(item => (
                      <p key = {item.AnimalID} style={{textAlign:"center"}}>{item.AnimalType}</p>
                    ))}
                  </td>

                </tr>
              </table>
            </div>
        );

    }

}

export default App;

