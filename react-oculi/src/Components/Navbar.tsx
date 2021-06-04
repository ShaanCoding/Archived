import oculii from "../images/oculii.png";

const Navbar = () => {
  return (
    <nav>
      <div>
        <div className="nav-left">
          <img src={oculii} />
        </div>

        <div className="nav-right">
          <a href="">Home</a>
          <a href="">Technology</a>
          <a href="">Products</a>
          <a href="">Company</a>
          <a href="">Contact</a>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
