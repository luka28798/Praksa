function User(props){
  return (
    <div className = "User">
      <UserCredentials userCredentials = {props.userCredentials}/>
      <UserAdverts userAdverts = {props.userAdverts}/>
    </div>
  )
}

function UserCredentials(props){
  return (
    <div className="UserCredentials">
      {props.userCredentials.Username}
      {props.userCredentials.Password}
    </div>
  );
}

function UserAdverts(props){
  return (
    <div className = "UserAdverts">
      {props.userAdverts.adverts}
    </div>
  )
}



export default User;
