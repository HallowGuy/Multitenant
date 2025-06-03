export default function Footer() {
  return (
    <footer className="bg-white border-t mt-auto py-4 text-center text-sm text-black fixed bottom-0 w-full">
      © {new Date().getFullYear()} MoonSite – Tous droits réservés.
    </footer>
  );
}
