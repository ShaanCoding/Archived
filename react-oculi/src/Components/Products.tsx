const Products: React.FC<{ title: string }> = (props) => {
  return (
    <div className="center box">
      <div className="products">
        <h1>{props.title}</h1>
        <div className="products-flexbox">{props.children}</div>
      </div>
    </div>
  );
};

export default Products;
