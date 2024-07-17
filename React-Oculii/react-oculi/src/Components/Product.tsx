const Product: React.FC<{
  productTitle: string;
  productDescription: string;
  productPerformance: string;
  productPerformanceDescription: string;
  productAzimuth: string;
  productElevation: string;
  productPropertiesList: string[];
}> = (props) => {
  const propertiesList = props.productPropertiesList.map(
    (properties: string) => (
      <li>
        <input type="checkbox" checked={true} readOnly={true} />
        <label>{properties}</label>
      </li>
    )
  );

  console.log(propertiesList);

  return (
    <div className="product">
      <h2>{props.productTitle}</h2>
      <p>{props.productDescription}</p>
      <h1>{props.productPerformance}</h1>
      <p>{props.productPerformanceDescription}</p>
      <div>
        <div>
          <h3>Azimuth</h3>
          <h2>{props.productAzimuth}</h2>
        </div>
        <div>
          <h3>Elevation</h3>
          <h2>{props.productElevation}</h2>
        </div>
      </div>
      <ul>{propertiesList}</ul>
      <button>Learn more</button>
    </div>
  );
};

export default Product;
