function Advert(props){
    return (
      <div className = "Advert">
        <AdvertInfo advertInfo = {props.advertInfo}/>
      </div>
    )
}
  
function AdvertInfo(props){
    return (
      <div className="AdvertInfo">
        {props.advertInfo.advertCategory}
        {props.advertInfo.advertTitle}
      </div>
    );
}
export default Advert;