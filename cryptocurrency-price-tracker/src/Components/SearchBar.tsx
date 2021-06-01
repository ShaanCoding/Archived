const SearchBar: React.FC<{ addFilter: (filterText: string) => void }> = (
  props
) => {
  const handleChange = (e: any) => {
    props.addFilter(e.target.value);
  };

  return (
    <form>
      <input
        type="text"
        placeholder="Search"
        className="coin-input"
        onChange={handleChange}
      />
    </form>
  );
};

export default SearchBar;
